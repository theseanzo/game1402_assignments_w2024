using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    

    #region MyCam Vars
    [SerializeField]
    [Range(0.1f, 1f)]
    float _cameraXSensitivity = 0.3f;

    Vector3 _offset = new Vector3(0, 0, 2f);
    float _smoothingRate = 0.35f;
    Transform _cameraPosition;
    [SerializeField]
    float _cameraDistance;
    #endregion

    private float lookAngle = 0, pivotAngle = 0;

    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerControls>().transform;
        _cameraPosition = GetComponentInChildren<Camera>().transform;
    }

    void Start()
    {
        _cameraDistance = _cameraPosition.position.magnitude;
    }

    private void HandleAllCameraMovement()
    {
        FollowTarget();
        HandleCameraLerp();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    public void RotateCamera(Vector2 movement)
    {
        lookAngle = lookAngle + movement.x * cameraLookSpeed * _cameraXSensitivity;
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

    void HandleCameraLerp()
    {
        Ray ray = new Ray(_cameraPosition.position, -_cameraPosition.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.25f, out hit, _cameraDistance))
        {
            _cameraPosition.localPosition = Vector3.back * hit.distance;
        }
        else
        {
            _cameraPosition.localPosition = Vector3.back * _cameraDistance;
        }
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
}
