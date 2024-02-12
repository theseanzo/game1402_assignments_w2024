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

    [Header("Input")]
    private float xMovement;
    private float yMovement;
    private float movementAmount;
    private float cameraMovementX;
    private float cameraMovementY;

    [SerializeField]
    bool isGrounded = true;
    [SerializeField]
    bool isJumping;
    [SerializeField]
    bool isSprinting;


    float inAirTimer;

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
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        animatorController.UpdateMovementValues(xMovement, yMovement, isSprinting);
    }
    private void LateUpdate()
    {
         GroundCheck();
    }
    
    
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
      // GroundCheck();
    }
    private void HandleInput()
    {
        // This is a placeholder. You should implement your input logic here,
        // including checking for strafe and jump inputs.
        if (Input.GetKeyDown(KeyCode.Space)) {
            HandleJumpInput();
        }

        // Example of strafing input (assuming A/D or LeftArrow/RightArrow for strafing)
        float strafe = Input.GetAxis("Horizontal");
        animatorController.UpdateStrafeValue(strafe);

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
                isJumping = false;
            }
        }
    }
    private void HandleMovement()
    {
        // Use camera's forward and right vectors to calculate move direction
        Vector3 forward = cameraObject.forward;
        Vector3 right = cameraObject.right;
        forward.y = 0; // Ensure the movement is strictly horizontal
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * yMovement + right * xMovement;
        moveDirection.Normalize(); // Normalize to ensure consistent speed

        // Apply different speeds based on player state
        float currentSpeed = isSprinting ? sprintSpeed : (Mathf.Abs(xMovement) + Mathf.Abs(yMovement) >= 0.5f ? runSpeed : walkSpeed);

        // Apply calculated movement
        Vector3 velocity = new Vector3(moveDirection.x * currentSpeed, rb.velocity.y, moveDirection.z * currentSpeed);
        rb.velocity = velocity;

    }

    private void HandleRotation()
    {
        // Align character's forward vector with the camera's forward vector, ignoring vertical orientation
        Vector3 forward = cameraObject.forward;
        forward.y = 0; // Ensure rotation is only on the Y axis
        forward.Normalize();

        if (forward != Vector3.zero) // Check to prevent warnings when vector is zero
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void HandleMovementInput(Vector2 movement)
    {
        xMovement = movement.x;
        yMovement = movement.y;
        movementAmount = Mathf.Abs(xMovement) + Mathf.Abs(yMovement);
        
        
    }
    public void HandleSprintInput(bool sprint)
    {
        isSprinting = sprint;
        //if (Input.GetButton("Sprint")) //Remember: GetKey, GetButton, etc. is for a button that's held down. GetKeyDown, GetButtonDown, etc. only trigger when the button is held down
        //{
        //    isSprinting = true;
        //}
        //else
        //{
        //    isSprinting = false;
        //}
    }
    public void HandleJumpInput()
    {
        if (isGrounded && !isJumping) {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            isGrounded = false;
            isJumping = true;
            animatorController.TriggerJumpAnimation(); // Trigger jump animation
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
