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
    float cameraDistance;
    [SerializeField]
    public Transform player;

    [SerializeField]
    float annoying;

    Vector3 Startingposition;




    private float lookAngle = 0, pivotAngle = 0;

        // Event callback example: Debug-draw all contact points and normals for 2 seconds.

    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        Startingposition = Camera.main.transform.localPosition;
        
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

    private void Oculude()
    {
        Ray ray = new Ray(transform.position, Camera.main.transform.position - targetTransform.position);
        RaycastHit hit;
        
        LayerMask mask = LayerMask.GetMask("player");
        if(Physics.Raycast(ray, out hit, cameraDistance, ~mask))
        {
            //Vector3 targetPosition = Vector3.SmoothDamp(Camera.main.transform.position, hit.point, ref cameraFollowVelocity, cameraFollowSpeed);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, hit.point, 10f * Time.deltaTime);
        }
        else
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, Startingposition, 10f * Time.deltaTime);
        }
    }
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }  

    void Update()
    {
        Oculude();
    }
    
}
