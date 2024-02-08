using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class CameraController : MonoBehaviour
{
    #region UnchangedStuff
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
    #endregion

    [SerializeField]
    private float cameraSmoothSpeed = 0.5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask wallLayer;

    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        //camera = GetComponentInChildren<Camera>();
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
        CameraRaycast();
    }

    private void CameraSmoothing(float alpha)
    {
        alpha = cameraSmoothSpeed;

    }

    private void CameraRaycast()
    {
        //RaycastHit hit;
        Vector3 cameraPos = GetComponentInChildren<Camera>().transform.position;
        Vector3 playerPos = targetTransform.position;
        Vector3 direction = playerPos - cameraPos;
        Debug.DrawRay(cameraPos, direction, Color.blue, 1.0f);
        if (Physics.Raycast(cameraPos, direction, transform.forward.magnitude, wallLayer))
        //if (Physics.SphereCast(cameraPos, 0.5f, direction, out hit, wallLayer))
        {
            Debug.Log("WE ARE IN THE BEAM");
        }
    }
}
