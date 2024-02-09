using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform targetTransform;
    [SerializeField] private Transform cameraPivot;

    [Header("Camera Settings")]
    [SerializeField] private float cameraFollowSpeed = 5f;
    [SerializeField] private float cameraLookSpeed = 2f;
    [SerializeField] private float cameraPivotSpeed = 2f;
    [SerializeField] private float minPivotAngle = -35f;
    [SerializeField] private float maxPivotAngle = 35f;
    [SerializeField] private float maxZoomDistance = 10f;
    [SerializeField] private float minZoomDistance = 2f;
    [SerializeField] private LayerMask collisionLayers; // Layers to consider for collision detection

    private float lookAngle = 0f;
    private float pivotAngle = 0f;
    private float currentZoomDistance = 5f;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }

    private void HandleAllCameraMovement()
    {
        FollowTarget();
        ZoomCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * cameraFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera(Vector2 movement)
    {
        lookAngle += movement.x * cameraLookSpeed;
        pivotAngle -= movement.y * cameraPivotSpeed;
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

    private void ZoomCamera()
    {
        RaycastHit hit;
        Vector3 raycastOrigin = cameraPivot.position;
        Vector3 raycastDirection = -cameraPivot.forward;

        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, maxZoomDistance, collisionLayers))
        {
            currentZoomDistance = Mathf.Clamp(hit.distance - 0.5f, minZoomDistance, maxZoomDistance);
        }
        else
        {
            currentZoomDistance = maxZoomDistance;
        }

        Vector3 newPosition = cameraPivot.localPosition;
        newPosition.z = -currentZoomDistance;
        cameraPivot.localPosition = newPosition;
    }
}
