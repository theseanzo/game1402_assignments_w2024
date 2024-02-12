using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraFollowVelocity = Vector3.zero;
    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    private float cameraFollowSpeed = .2f;
    [SerializeField]
    private float cameraLookSpeed = 2f;
    [SerializeField]
    private float cameraPivotSpeed = 2f;
    [SerializeField]
    float minPivotAngle = -35;
    [SerializeField]
    float maxPivotAngle = 35;
    [SerializeField]
    Transform cameraPivot;
    public float cameraDistance;


    private float lookAngle = 0, pivotAngle = 0;
    private void HandleAllCameraMovement()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera(Vector2 movement)
    {
        lookAngle = lookAngle + movement.x * cameraLookSpeed;
        pivotAngle = pivotAngle - (movement.y * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);
        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
        Ray ray = new Ray(this.transform.position, -this.transform.forward);
        RaycastHit hit;//Raycast
        if (Physics.SphereCast(ray, 0.7f, out hit, cameraDistance))// tried to get this to smooth using Mathf.Lerp but got errors
        {
            cameraPivot.localPosition = Vector3.back * hit.distance;
        }
        else
        {
            cameraPivot.localPosition = Vector3.back * cameraDistance;
        }
    }
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
}
