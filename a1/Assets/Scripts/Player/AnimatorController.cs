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
        //this happens at approximately when the program loads
        taunt = StartCoroutine(FallDown());
        Invoke("StopFalling", 11f);
    }

    void StopFalling()
    {
        StopCoroutine(taunt);
    }
    IEnumerator FallDown()
    {
        
        for(int i = 0; i < 5; i++)
        { 
            animator.SetTrigger("FallDown");
            yield return new WaitForSeconds(5f);
        }

    }
    public void Jump(bool isJumping)
    {
        if(isJumping)
        {
            StartCoroutine(Jumping(true));
        }
        else
            StopCoroutine(taunt);

    }
    IEnumerator Jumping(bool jumpState)
    {
        
        animator.SetTrigger("IsJumping");
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
