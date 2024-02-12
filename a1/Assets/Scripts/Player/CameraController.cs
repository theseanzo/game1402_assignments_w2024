using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Existing variables
    private Vector3 cameraFollowVelocity = Vector3.zero;
    [SerializeField] Transform targetTransform;
    [SerializeField] private float cameraFollowSpeed = .2f;
    [SerializeField] private float cameraLookSpeed = 2f;
    [SerializeField] private float cameraPivotSpeed = 2f;
    [SerializeField] float minPivotAngle = -35;
    [SerializeField] float maxPivotAngle = 35;
    [SerializeField] Transform cameraPivot;
    [SerializeField] private Camera camera;

    // Camera collision variables
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private float cameraCollisionOffset = 0.2f;
    [SerializeField] private float minimumDistanceFromTarget = 1f;
    [SerializeField] private float zoomSmoothness = 0.5f; // Smoothness parameter for zooming in and out
    private float currentZoomDistance;
    private float defaultDistance;

    private float lookAngle = 0, pivotAngle = 0;

    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        camera = GetComponentInChildren<Camera>();
        defaultDistance = camera.transform.localPosition.z;
        currentZoomDistance = defaultDistance;
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
        CameraCollision();
    }

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
        lookAngle += movement.x * cameraLookSpeed;
        pivotAngle -= movement.y * cameraPivotSpeed;
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        Quaternion targetRotation = Quaternion.Euler(0, lookAngle, 0);
        transform.rotation = targetRotation;

        targetRotation = Quaternion.Euler(pivotAngle, 0, 0);
        cameraPivot.localRotation = targetRotation;
    }

    private void CameraCollision()
    {
        Vector3 desiredCameraPos = cameraPivot.TransformPoint(new Vector3(0, 0, currentZoomDistance));
        RaycastHit hit;

        bool isBlocked = Physics.Linecast(cameraPivot.position, desiredCameraPos, out hit, collisionLayer);
        float targetDistance = isBlocked ? hit.distance - cameraCollisionOffset : defaultDistance;

        if (isBlocked && targetDistance < minimumDistanceFromTarget)
        {
            targetDistance = minimumDistanceFromTarget;
        }

        currentZoomDistance = Mathf.Lerp(currentZoomDistance, targetDistance, zoomSmoothness * Time.deltaTime);

        camera.transform.position = cameraPivot.TransformPoint(new Vector3(0, 0, currentZoomDistance));
    }
}
