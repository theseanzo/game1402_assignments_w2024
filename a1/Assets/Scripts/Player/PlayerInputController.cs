using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerController playerController;
    private CameraController cameraController;
    PlayerInput playerInput;

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        cameraController = FindObjectOfType<CameraController>(); //this is not a good function to normally use unless it's a singleton, because you can typically have more than one object in a scene
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.PlayerMovement.Movement.performed += i => playerController.HandleMovementInput(i.ReadValue<Vector2>());
            playerInput.PlayerMovement.Camera.performed += i => cameraController.RotateCamera(i.ReadValue<Vector2>());
            playerInput.PlayerActions.Sprint.performed += i => playerController.HandleSprintInput(true);
            playerInput.PlayerActions.Sprint.canceled += i => playerController.HandleSprintInput(false);
            playerInput.PlayerActions.Jump.started += i => playerController.HandleJumpInput();
            //a lambda function is of the type (parameters)=>one_line_function;
            //if multiple lines (parameters)=>{}


        }
        playerInput.Enable();
    }

}
