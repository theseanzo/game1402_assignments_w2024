using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour, PlayerInput.IPlayerMovementActions, PlayerInput.IPlayerActionsActions
{
    StateMachine _playerStateMachine;

    [Header("Movement Variables")]
    public float WalkSpeed = 1.5f;
    public float RunSpeed = 4.5f;
    public float SprintSpeed = 7.5f;

    public float CurrentSpeed { get; set; }

    public Vector2 InputVector { get; private set; }

    [Header("Components")]
    [SerializeField]
    public Rigidbody Rb;
    [SerializeField]
    public Animator Animator { get; private set; }
    [SerializeField]
    public SphereCollider GroundDetectionColider;
    private System.Numerics.Vector2 directionInputVector;

    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        GroundDetectionColider = GetComponent<SphereCollider>();
        Animator = GetComponent<Animator>();

        _playerStateMachine =  new StateMachine(this);
    }

    void Start()
    {
        _playerStateMachine.Init(_playerStateMachine._idleState);
    }

    void Update()
    {
        _playerStateMachine.Update();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnCamera(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        _playerStateMachine.TransitionTo(_playerStateMachine._jumpState);
    }
}