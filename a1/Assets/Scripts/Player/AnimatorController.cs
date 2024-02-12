using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void UpdateMovementValues(float xMovement, float yMovement, bool isSprinting = false)
    {
        float snappedX = SnapValues(xMovement, 0.55f, 0.5f, 1.0f);
        float snappedY = SnapValues(yMovement, 0.55f, 0.5f, 1.0f);
        if (isSprinting)
        {
            snappedY = 2f;
        }
        animator.SetFloat("XMovement", snappedX, .1f, Time.deltaTime);
        animator.SetFloat("YMovement", snappedY, .1f, Time.deltaTime);
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

    public void BeginJump() //The way I implemented these animations is REALLY awful, but my brain is too melted right now to make a better one
    {
        animator.SetBool("IsGrounded", false);
        animator.SetBool("IsJumping", true);
        Invoke("BeginFall", 0.25f);
    }

    public void BeginFall()
    {
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsJumping", false);
    }

    public void EndJump()
    {
        animator.SetBool("IsGrounded", true);
        animator.SetBool("IsFalling", false);
    }

    public void StrafeLeft()
    {
        animator.SetFloat("IsStrafing", 1);
    }
    public void StrafeRight()
    {
        animator.SetFloat("IsStrafing", -1);
    }
    public void StopStrafe()
    {
        animator.SetFloat("IsStrafing", 0);
    }
}
