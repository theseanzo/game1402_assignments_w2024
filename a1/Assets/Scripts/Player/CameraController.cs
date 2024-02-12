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
    private float _cameraZoomSpeed = 0.2f;
    [SerializeField]
    float minPivotAngle = -35;
    [SerializeField]
    float maxPivotAngle = 35;
    [SerializeField]
    Transform cameraPivot;

    [SerializeField]
    private float _cameraMaxDistance = 3.5f;
    [Header("Debug")]
    [SerializeField]
    private bool _showDebugRays = true;
    private float lookAngle = 0, pivotAngle = 0;
    private Vector3 _targetPositionOffset;
    private Camera _cameraObject;
    void Awake()
    {
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        targetTransform = player.transform;

        CapsuleCollider collider = player.GetComponent<CapsuleCollider>();
        // Use offset to target player midsection instead of feet
        _targetPositionOffset = new Vector3(0, collider.height * 0.5f, 0);

        _cameraObject = Camera.main;
    }
    private void Start()
    {
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        CapsuleCollider collider = player.GetComponent<CapsuleCollider>();

        // Use offset to target player midsection instead of feet
        _targetPositionOffset = new Vector3(0, collider.height * 0.5f, 0);
    }
    private void HandleAllCameraMovement()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        bool onHit = false;

        // Default values when view is not blocked
        float cameraMoveSpeed = cameraFollowSpeed;
        Vector3 targetPosition = targetTransform.position;

        Vector3 adjustTargetPosition = targetTransform.position + _targetPositionOffset;
        Vector3 screenPos = _cameraObject.WorldToScreenPoint(adjustTargetPosition);
        Ray ray = _cameraObject.ScreenPointToRay(screenPos);
        RaycastHit hitInfo;

        // Cast ray from target to camera instead of camera to target to get best position to place camera
        if(onHit = Physics.Raycast(adjustTargetPosition, -ray.direction, out hitInfo, _cameraMaxDistance))
        {
            targetPosition = adjustTargetPosition + (ray.direction.normalized * (_cameraMaxDistance - hitInfo.distance));
            cameraMoveSpeed = _cameraZoomSpeed;
        }

        targetPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraFollowVelocity, cameraMoveSpeed);
        transform.position = targetPosition;

        if(_showDebugRays)
        {
            Debug.DrawRay(adjustTargetPosition, -ray.direction * _cameraMaxDistance, onHit ? Color.red : Color.green);
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
