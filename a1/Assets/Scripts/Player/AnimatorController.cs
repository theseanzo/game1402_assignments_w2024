using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Coroutine taunt;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMovementValues(float xMovement, float yMovement, bool isSprinting = false)
    {
        float snappedX = SnapValues(xMovement, 0.55f, 1.0f, 1.0f);
        float snappedY = SnapValues(yMovement, 0.55f, 0.5f, 1.0f);
        if (isSprinting)
        {
            snappedY = 2f;
        }
        animator.SetFloat("XMovement", snappedX, .1f, Time.deltaTime);
        animator.SetFloat("YMovement", snappedY, .1f, Time.deltaTime);
    }

    public void HandleAirborneAnimations(Vector3 airVelocity)
    {
        if(airVelocity.y > 0.5f)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if(airVelocity.y < -0.5f)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
        }
    }

    private float SnapValues(float value, float lowerBound, float lowValue, float highValue)
    {
        if (value > 0 && value < lowerBound)
        {
            return lowValue;
        }
        else if (value > lowerBound)
        {
            return highValue;
        }
        else if (value < 0 && value < -lowerBound)
        {
            return -lowValue;
        }
        else if (value < -lowerBound)
        {
            return -highValue;
        }
        return 0f;

    }
}
