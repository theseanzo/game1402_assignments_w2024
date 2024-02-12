using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private float cameraSmoothSpeed = 0.5f; //I couldn't figure out how to get this to work!
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

    private void CameraRaycast() //I know you keep telling me to stop apologising for my submissions, but I must insist on an apology for this code. Sorry!
    {
        Vector3 targetPosition;
        RaycastHit hit;
        Vector3 cameraPos = GetComponentInChildren<Camera>().transform.position;
        Vector3 playerPos = targetTransform.localPosition;
        Vector3 direction = cameraPos - playerPos;
        float cameraDistance = Vector3.Distance(cameraPos, playerPos);
        Ray cameraRay = new Ray(playerPos, direction);
        Debug.DrawRay(playerPos, direction, Color.blue, 1.0f);
        if (Physics.SphereCast(cameraRay, 0.05f, out hit, cameraDistance, wallLayer) || Physics.SphereCast(cameraRay, 0.25f, out hit, cameraDistance, groundLayer))
        {
            //Debug.Log("Camera is in wall at " + hit.point);
            targetPosition = Vector3.SmoothDamp(transform.position, hit.point + (transform.forward * 4), ref cameraFollowVelocity, cameraFollowSpeed);
            transform.position = targetPosition;
        }
    }
}