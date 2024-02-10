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

    public void UpdateMovementValues(float xMovement, float yMovement, bool isStrafing = false, bool isSprinting = false)
    {
        float snappedX = SnapValues(xMovement, 0.55f, 0.5f, 1.0f);
        float snappedY = SnapValues(yMovement, 0.55f, 0.5f, 1.0f);
        if (isSprinting)
        {
            snappedY = 2f;
        }

        animator.SetFloat("YMovement", snappedY, .1f, Time.deltaTime);

        if (isStrafing)
        {
            animator.SetFloat("XMovement", snappedX, .1f, Time.deltaTime);
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
