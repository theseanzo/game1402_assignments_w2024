using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    private PlayerControls _player;

    readonly int _forwardSpeedHash = Animator.StringToHash("YMovement");
    readonly int _strafeHash = Animator.StringToHash("XMovement");
    readonly int _locomotionHash = Animator.StringToHash("Locomotion");

    float _animatorDampTime = 0.1f;
    float _rotationDamping = 8f;
    float _currentSpeed;

    public PlayerMoveState(PlayerControls player)
    {
        this._player = player;
    }

    public void EnterState()
    {
        _player.Animator.CrossFadeInFixedTime(_locomotionHash, _animatorDampTime);
        Debug.Log("Now entering Move State vroom!");
    }

    public void Update()
    {
        Vector3 movementDir = HandleMovement();

        MovementAnims();
        HandleRotation();

        Move(movementDir);
    }

    public void ExitState()
    {
        Debug.Log("Exiting movement State");
    }

    Vector3 HandleMovement()
    {
        Vector3 motion = new Vector3();
        motion.x = _player.MovementVector.x;
        motion.y = 0f;
        motion.z = _player.MovementVector.y;
        Vector3 cameraForward = _player.CameraFocusPoint.forward;
        Vector3 cameraRight = _player.CameraFocusPoint.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        return cameraForward * motion.z + cameraRight * motion.x;
    }

    void Move(Vector3 inputVector)
    {
        _player.Rb.velocity = inputVector * _currentSpeed;
    }

    void MovementAnims()
    {
        if (_player.MovementVector == Vector2.zero)
        {
            _currentSpeed = 0f;
            _player.Animator.SetFloat(_forwardSpeedHash, 0f, _animatorDampTime, Time.deltaTime);
            _player.PlayerStateMachine.TransitionTo(_player.PlayerStateMachine._idleState);
        }
        if (_player.IsSprinting)
        {
            _currentSpeed = _player.SprintSpeed;
            _player.Animator.SetFloat(_forwardSpeedHash, 2f, _animatorDampTime, Time.deltaTime);
        }
        else
        {
            if (_player.MovementVector.y <= 1f)
            {
                _currentSpeed = _player.RunSpeed;
                _player.Animator.SetFloat(_forwardSpeedHash, _player.MovementVector.y, _animatorDampTime, Time.deltaTime);
            }
            else if (_player.MovementVector.y <= 0.5f)
            {
                _currentSpeed = _player.WalkSpeed;
                _player.Animator.SetFloat(_forwardSpeedHash, _player.MovementVector.y, _animatorDampTime, Time.deltaTime);
            }
        }

        if (Mathf.Abs(_player.MovementVector.x) > 0f)
        {
            _currentSpeed = _player.StrafeSpeed;
            _player.Animator.SetFloat(_strafeHash, _player.MovementVector.x, _animatorDampTime, Time.deltaTime);
        }
    }

    void HandleRotation()
    {
        Vector3 targetDir = Vector3.zero;
        targetDir = _player.CameraFocusPoint.forward * _player.MovementVector.y;
        targetDir.Normalize();
        targetDir.y = 0f;

        if (targetDir == Vector3.zero)
            targetDir = _player.transform.forward;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDir);
        Quaternion playerRotation = Quaternion.Slerp(_player.transform.rotation, targetRotation, _rotationDamping * Time.deltaTime);

        _player.transform.rotation = playerRotation;
    }
}
