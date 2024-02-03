using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public StateMachine PlayerStateMachine;
    #region MovementVariables
    [Header("Movement Variables")]
    [SerializeField]
    public float WalkSpeed = 1.5f;
    [SerializeField]
    public float RunSpeed = 4.5f;
    [SerializeField]
    public float SprintSpeed = 7.5f;
    [SerializeField]
    public float StrafeSpeed = 3f;

    public Vector2 MovementVector = new Vector2();

    public bool IsSprinting = false;
    #endregion
    #region Components
    [Header("Components")]
    [SerializeField]
    public Rigidbody Rb;
    [SerializeField]
    public Animator Animator { get; private set; }
    [SerializeField]
    public SphereCollider GroundDetectionColider;

    public Transform CameraFocusPoint;
    #endregion

    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        GroundDetectionColider = GetComponent<SphereCollider>();
        Animator = GetComponent<Animator>();

        PlayerStateMachine =  new StateMachine(this);
        CameraFocusPoint = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        PlayerStateMachine.Init(PlayerStateMachine._idleState);
    }

    void Update()
    {
        PlayerStateMachine.Update();
    }

    public void HandleMovementInput(Vector2 movement)
    {
        MovementVector = movement;

        if (movement == Vector2.zero) { return; }
        PlayerStateMachine.TransitionTo(PlayerStateMachine._moveState);
    }

    public void HandleSprintInput(bool isSprinting)
    {
        IsSprinting = isSprinting;
    }

    public void HandleJump()
    {
        // 
    }
}