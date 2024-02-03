using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerControls _playerControls;
    CameraController _temp;
    PlayerInput _playerInput;

    void OnEnable()
    {
        _playerControls = GetComponent<PlayerControls>();
        _temp = FindObjectOfType<CameraController>();

        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.PlayerMovement.Movement.performed += i => _playerControls.HandleMovementInput(i.ReadValue<Vector2>());
            _playerInput.PlayerMovement.Camera.performed += i => _temp.RotateCamera(i.ReadValue<Vector2>());
            _playerInput.PlayerActions.Sprint.performed += i => _playerControls.HandleSprintInput(true);
            _playerInput.PlayerActions.Sprint.canceled += i => _playerControls.HandleSprintInput(false);
            _playerInput.PlayerActions.Jump.started += i => _playerControls.HandleJump();
        }
        _playerInput.Enable();
    }
}
