using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IPlayerState
{
    private PlayerControls player;

    public PlayerJumpState(PlayerControls player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        Debug.Log("Jumping so high");
    }

    public void Update()
    {
        // 
    }

    public void ExitState()
    {
        Debug.Log("Leaving Jump State");
    }
}
