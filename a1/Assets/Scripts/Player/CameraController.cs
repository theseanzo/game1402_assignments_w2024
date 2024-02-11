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
    private float cameraZoomSpeed = 0.2f;
    [SerializeField]
    float minPivotAngle = -35;
    [SerializeField]
    float maxPivotAngle = 35;
    [SerializeField]
    Transform cameraPivot;
    [SerializeField]
    private bool _showDebugRays = true;
    private float lookAngle = 0, pivotAngle = 0;
    private Vector3 targetPositionOffset;
    private float cameraMaxDistance;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        
    }
    private void Start()
    {
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        CapsuleCollider collider = player.GetComponent<CapsuleCollider>();

        //Use offset to target player midsection instead of feet
        targetPositionOffset = new Vector3(0, collider.height * 0.5f, 0);
    }
    private void HandleAllCameraMovement()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        Vector3 adjustTargetPosition = targetTransform.position + targetPositionOffset;
        
        //float distance = Vector3.Distance(adjustTargetPosition, Camera.main.transform.position);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(adjustTargetPosition);
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hitInfo;

        Vector3 targetPosition = targetTransform.position;
        Color debugRayColor = Color.green;
        float cameraMoveSpeed = cameraFollowSpeed;
        cameraMaxDistance = 3.5f;
        
        if(Physics.Raycast(adjustTargetPosition, -ray.direction, out hitInfo, cameraMaxDistance))
        {
            targetPosition = adjustTargetPosition + (ray.direction.normalized * (cameraMaxDistance - hitInfo.distance));
            cameraFollowSpeed = cameraZoomSpeed;
            debugRayColor = Color.red;
        }

        targetPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraFollowVelocity, cameraMoveSpeed);
        transform.position = targetPosition;

        if(_showDebugRays)
        {
            Debug.DrawRay(adjustTargetPosition, -ray.direction * cameraMaxDistance, debugRayColor);
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
