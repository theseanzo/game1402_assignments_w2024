using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{
    #region SerializeField
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
    float sphereRadius = 0.4f;
    [SerializeField]
    float cameraSmoothness = 10f;
    [SerializeField]
    float characterDistance = 3;
    #endregion

    Camera mainCamera;

    private Vector3 cameraFollowVelocity = Vector3.zero;
    private float lookAngle = 0;
    private float pivotAngle = 0;

    Vector3 initialCameraPosition;

    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.localPosition;
    }

    private void HandleAllCameraMovement()
    {
        LayerMask LayerMask = LayerMask.GetMask("Player", "Ground", "Foliage");

        Ray ray = new(targetTransform.position, mainCamera.transform.position - targetTransform.position);
        Debug.DrawRay(targetTransform.position, mainCamera.transform.position - targetTransform.position, Color.red);
        
        RaycastHit hit;
        if (Physics.SphereCast(ray, sphereRadius, out hit, characterDistance, ~LayerMask))
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, hit.point, cameraSmoothness * Time.deltaTime); //perform camera zoom when blocked from view
        }
        else
        {
            mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, initialCameraPosition, cameraSmoothness * Time.deltaTime); //normalize camera zoom
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

    // Draw a Sphere Gizmo around the camera based on sphereRadius
    void OnDrawGizmos()
    {
        if (Application.IsPlaying(this))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(mainCamera.transform.position, sphereRadius);
        }
    }
}
