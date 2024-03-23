using UnityEngine;

public class FrictionGoat : A2Animal
{
    /// <summary>
    /// Manages the motion of goats with consideration to frictional forces.
    /// </summary>

    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private Rigidbody rigidBodyComponent;
    private bool _currentlyMoving = false;
    
    private void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    public void Move()
    {
            /** Automatically handles friction for us  **/
            if (rigidBodyComponent != null)
                rigidBodyComponent.AddForce(transform.forward * speed, ForceMode.VelocityChange);
            _currentlyMoving = true;
    }

    private void FixedUpdate()
    {
        if (rigidBodyComponent != null && _currentlyMoving && rigidBodyComponent.velocity.magnitude < 0.1f)
        {
            _currentlyMoving = false;
            rigidBodyComponent.velocity = Vector3.zero;
        }
    }
}