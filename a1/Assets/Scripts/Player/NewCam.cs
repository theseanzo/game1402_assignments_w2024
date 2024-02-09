using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCam : MonoBehaviour
{
    public Transform targetTransform;
    public float cameraSpeed;
    public Transform cameraTransform;
    public float cameraDistance;
    private float cameraFollowSpeed = .2f;
    private Vector3 cameraFollowVelocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        
        transform.position = targetPosition;
        

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation *= Quaternion.Euler(0, cameraSpeed * Input.GetAxis("Mouse X"), 0);
        cameraTransform.localPosition = Vector3.back * 10;

        Ray ray = new Ray(this.transform.position, -this.transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray,0.5f, out hit, cameraDistance))
        {
            cameraTransform.localPosition = Vector3.back * hit.distance;
        }
        else
        {
            cameraTransform.localPosition = Vector3.back * cameraDistance;
        }
    }
}
