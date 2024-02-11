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

    //variables for sphere cast
    [SerializeField]
    Vector3 cameraDistance;
    Transform cameraTransform;
    [SerializeField]
    float cameraSmooth;


    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }
    void Start()
    {
        cameraDistance = cameraTransform.localPosition;
    }
    private void HandleAllCameraMovement()
    {
        FollowTarget();
        CameraCast();
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
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
    void CameraCast()
    {
        RaycastHit hit;
        LayerMask playerMask = ~LayerMask.GetMask("Player");
        Ray ray = new Ray(targetTransform.position, (cameraTransform.position - targetTransform.position));
        if(Physics.Raycast(ray.origin, ray.direction, out hit, 10f, playerMask))
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, hit.point, cameraSmooth * Time.deltaTime);
            Debug.Log("Hit");
        }
        else
        {
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraDistance, cameraSmooth * Time.deltaTime);
        }
    }
}
