using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    [SerializeField]
    public float cameraSpeed;
    public Transform cameraTransform;
    [SerializeField]
    public float cameraDistance;
    [SerializeField]
    private float radius = 0.25f;

    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(0, cameraSpeed * Input.GetAxis("Mouse X"), 0);


        Ray ray = new Ray(this.transform.position, -this.transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, radius, out hit, cameraDistance))
        {
            cameraTransform.localPosition = Vector3.back * hit.distance;
        }
        else
        {
            cameraTransform.localPosition = Vector3.back * cameraDistance;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(cameraTransform.position, radius);
    }
}
