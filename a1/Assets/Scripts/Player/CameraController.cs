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

    Transform _cameraPosition;
    [SerializeField]
    GameObject _playerObject;
    

    // Camera Variables I made.
    [SerializeField]
    [Range(0.1f, 1f)]
    float _cameraXSensitivity = 0.3f;

    Vector3 _offset = new Vector3(0, 0, 2f);
    float _smoothingRate = 0.35f;

    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerControls>().transform;
        _cameraPosition = GetComponentInChildren<Camera>().transform;
    }

    void Start()
    {
        if (_playerObject != null) { return; }
        _playerObject = FindObjectOfType<PlayerControls>().gameObject;
        Debug.Log($"{_playerObject.name} found!");
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
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.225f, 0f));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != _playerObject)
            {
                _cameraPosition.position = Vector3.Lerp(_cameraPosition.position, targetTransform.position, _smoothingRate * Time.deltaTime);
            }
            else
            {
                _cameraPosition.position = Vector3.Lerp(_cameraPosition.position, transform.position, _smoothingRate * Time.deltaTime);
            }
            Debug.Log(hit.collider.name);
        }
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
}
