using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    LayerMask cameraCollisionLayer;

    Transform cameraPosition;
    [SerializeField]
    Vector3 cameraOffset;
    [SerializeField]
    Vector3 cameraDistance;
    [SerializeField]
    float smoothingRate = 0.75f;

    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        cameraPosition = GetComponentInChildren<Camera>().transform;
    }
    private void HandleAllCameraMovement()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        Vector3 occlusionDistance = cameraPivot.localPosition;
        RaycastHit hit;
        Debug.DrawRay(FindObjectOfType<PlayerController>().transform.position, (cameraPosition.position - targetTransform.position));
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;

        if (Physics.Raycast(targetTransform.position, (cameraPosition.position - targetTransform.position), out hit, 10.0f, cameraCollisionLayer))
        {
            cameraPosition.position = Vector3.Lerp(cameraPosition.position, hit.point, smoothingRate * Time.deltaTime);
        }
        else
        {
            cameraPosition.localPosition = Vector3.Lerp(cameraPosition.localPosition, cameraDistance, smoothingRate * Time.deltaTime);
        }
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
    }
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
}
