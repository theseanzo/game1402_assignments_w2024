using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float cameraDistance;
    public float radius = 0.25f;

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

    Vector3 cameraPos;


    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        //camera = GetComponentInChildren<Camera>();
        cameraPos = Camera.main.transform.localPosition;
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

    private void HideView()
    {
        Ray raycast = new Ray(targetTransform.position, Camera.main.transform.position - targetTransform.position);
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Player");
        if (Physics.Raycast(raycast, out hit, cameraDistance, layerMask))
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, hit.point, 10f * Time.deltaTime);
        }
        else
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, cameraPos, 10f * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }

    private void Update()
    {
        HideView();
    }
}
