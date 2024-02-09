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

    [SerializeField]
    Camera _camera;

    [SerializeField]
    float _cameraLerpSpeed;

    Vector3 _cameraOriginalPosition;

    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        _camera = Camera.main;
        _cameraOriginalPosition = _camera.transform.localPosition;
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
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }

    private void Update()
    {
        ObstacleOcclusion();
    }

    //Handles the object occlusion of the camera
    private void ObstacleOcclusion()
    {
        LayerMask playerOcclusionMask = ~LayerMask.GetMask("Player");

        RaycastHit hit;
        
        if (Physics.Raycast(targetTransform.position, _camera.transform.position - targetTransform.position, out hit, 5f, playerOcclusionMask))
        {
            Camera.main.transform.position = Vector3.Lerp(_camera.transform.position, hit.point, _cameraLerpSpeed * Time.deltaTime);
        }
        else
        {
            _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, _cameraOriginalPosition, _cameraLerpSpeed * Time.deltaTime);
        }
    }
}
