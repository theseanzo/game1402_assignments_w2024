using UnityEngine;


public class CameraController : MonoBehaviour
{
    
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
    float sphereRadius = 0.5f;

    Camera camera;

    private Vector3 cameraFollowVelocity = Vector3.zero;
    private float lookAngle = 0;
    private float pivotAngle = 0;
    public float cameraDistance;


    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        camera = GetComponentInChildren<Camera>();
    }

    private void HandleAllCameraMovement()
    {
        //Move Camera back until we get near a Physics Collider
        Ray ray = new Ray(camera.transform.position, -camera.transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, sphereRadius, out hit, cameraDistance))
        {
            camera.transform.localPosition = Vector3.back * hit.distance;
        }
        else
        {
            camera.transform.localPosition = Vector3.back * cameraDistance;
        }

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

    private void FixedUpdate()
    {
        HandleAllCameraMovement();
    }

    // Draw a Gizmo around where the camera has been projected to
    void OnDrawGizmos()
    {
        if (Application.IsPlaying(this))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(camera.transform.position, sphereRadius);

        }
    }
}
