using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Existing variables
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
    private Camera camera;

    // Camera collision variables
    [SerializeField]
    private LayerMask obstacleLayer;
    [SerializeField]
    private float cameraCollisionOffset = 0.2f;
    [SerializeField]
    private float minZoom = 1f;
    [SerializeField]
    private float zoomSmoothness = 0.5f; // Smoothness parameter for zooming in and out
    private float zoomDistance;
    private float defaultDistance;

    private float lookAngle = 0, pivotAngle = 0;

    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        camera = GetComponentInChildren<Camera>();
        defaultDistance = camera.transform.localPosition.z;
        zoomDistance = defaultDistance;
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
        AdjustZoomForObstacles();
    }

    private void AdjustZoomForObstacles()
    {
        Vector3 targetPosition = cameraPivot.TransformPoint(Vector3.forward * zoomDistance);
        RaycastHit obstacleInfo;

        bool hasCollision = Physics.Linecast(cameraPivot.position, targetPosition, out obstacleInfo, obstacleLayer);
        float adjustedZoom = hasCollision ? obstacleInfo.distance - cameraCollisionOffset : defaultDistance;

        if (hasCollision && adjustedZoom < minZoom)
        {
            adjustedZoom = minZoom;
        }

        zoomDistance = Mathf.Lerp(zoomDistance, adjustedZoom, zoomSmoothness * Time.deltaTime);

        camera.transform.position = cameraPivot.TransformPoint(Vector3.forward * zoomDistance);
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
}
