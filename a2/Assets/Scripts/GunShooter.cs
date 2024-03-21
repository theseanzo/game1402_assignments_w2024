using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private StarterAssetsInputs _input;

    [SerializeField]
    Projectile bulletPrefab;
    [SerializeField]
    Transform fireLocation;
    [SerializeField]
    float projectileForce = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    public void Shoot()
    {
        //similar to what we have seen before. we Instantiate a prefab at a particular location and at a particular rotation
        //we then shoot the projectile in a direction
        Projectile projectile = Instantiate(bulletPrefab, fireLocation.position, fireLocation.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(-transform.right * projectileForce, ForceMode.Impulse); //because the 3d model aims to the left, our projectile needs to get force added to it in that same direction
    }
}
