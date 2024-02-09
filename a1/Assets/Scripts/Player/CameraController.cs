using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraFollowVelocity = Vector3.zero;
    Ray cameraRay;
    RaycastHit hit;
    float cameraRadius = 0.2f; //Radius for the sphere casting in which it can hit objects
    float cameraDistance = 3f;
    float cameraZoom = 20f;
    float normalFieldOfView; //Used for Camera 
    float zoomedFieldOfView; //Used for Camera 

    [SerializeField]
    Transform cameraTransform; //Used for the sphere casting

    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    Camera camera;

    [SerializeField]
    private float cameraFollowSpeed = 0.2f;

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
    float cameraSmoothness; 


    private float lookAngle = 0, pivotAngle = 0;
    void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        normalFieldOfView = camera.fieldOfView;
        zoomedFieldOfView = normalFieldOfView - cameraZoom;
        //camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(0, cameraLookSpeed * Input.GetAxis("Mouse X"), 0);
        cameraRay = new Ray(this.transform.position, -this.transform.forward);

        if(Physics.SphereCast(cameraRay, cameraRadius, out hit, cameraDistance)) //If sphere cast hits something:
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomedFieldOfView, Time.deltaTime * cameraZoom * cameraSmoothness); //Zooming in
            
        else
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normalFieldOfView, Time.deltaTime * cameraZoom * cameraSmoothness); //Zooming out    
            
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
}
