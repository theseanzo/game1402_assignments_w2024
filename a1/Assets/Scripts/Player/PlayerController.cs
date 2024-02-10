using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This is a standard 3D player controller
    AnimatorController animatorController;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rb;

    #region SerializeField
    [Header("Movement")]
    [SerializeField]
    private float rotationSpeed = 15f;
    [SerializeField]
    float walkSpeed = 1.5f;
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 7f;

    [Header("Falling")]
    [SerializeField]
    float rayCastHeightOffset = 0.1f;
    [SerializeField]
    LayerMask groundLayer;

    [Header("Jump info")]
    [SerializeField]
    float jumpForce = 20f;
    #endregion

    #region private/default
    [Header("Input")]
    private float xMovement;
    private float yMovement;
    private float movementAmount;

    bool isGrounded = true;
    bool isJumping;
    bool isSprinting;
    bool isStrafing;

    float inAirTimer;
    #endregion

    SkinnedMeshRenderer meshRenderer;

    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>(); //this grabs the AnimatorController
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();//remember this when dealing with 3d models as they typically do not have the mesh renderer in the same place as where you put all of your animators, scripts, etc 
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        StartCoroutine(ChangePlayerColor());
    }

    IEnumerator ChangePlayerColor()
    {
        float alpha = 0.0f;
        bool upOrDown = true;
        while (true)
        {
            alpha += 0.005f * (upOrDown ? 1f : -1f);
            if (alpha >= 1.0f || alpha <= 0.0f)
                upOrDown = !upOrDown;

            meshRenderer.material.SetColor("_Color", Color.white * alpha);
            yield return new WaitForFixedUpdate();
        }

        
    }

    void Update()
    {
        animatorController.UpdateMovementValues(xMovement, yMovement, isStrafing, isSprinting);
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void GroundCheck() //this is where we figure out if we are on the ground or not
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if (!isGrounded)
        {
            if (Physics.SphereCast(rayCastOrigin, 0.5f, -Vector3.up, out hit, 0.5f, groundLayer))
            {
                isGrounded = true;
            }
        }

    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * yMovement;
        moveDirection += cameraObject.right * xMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (isSprinting)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else
        {
            if (movementAmount >= 0.5f && !isStrafing)
            {
                moveDirection = moveDirection * runSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkSpeed;
            }
        }
        
        moveDirection.y = rb.velocity.y;
        rb.velocity = moveDirection;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * yMovement;

        if (xMovement < 0) {
            targetDirection = targetDirection + (cameraObject.forward * -1) * xMovement; //left strafe
             
        }
        else if (xMovement > 0)
        {
            targetDirection = targetDirection + (cameraObject.forward) * xMovement; //right strafe
        }

        targetDirection.Normalize();
        targetDirection.y = 0;
        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    public void HandleMovementInput(Vector2 movement)
    {
        xMovement = movement.x;
        yMovement = movement.y;
        movementAmount = Mathf.Abs(xMovement) + Mathf.Abs(yMovement);

        isStrafing = xMovement < 0 || xMovement > 0 ? true : false;
    }

    public void HandleSprintInput(bool sprint)
    {
        isSprinting = sprint;
    }

    public void HandleJumpInput()
    {
        if (isGrounded)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce; //change our y velocity to be whatever we want it to be for jumping up
            rb.velocity = velocity; //reattach that to our rigid body
            isGrounded = false; //inform that we are no longer on the ground
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = false;
    }
}
