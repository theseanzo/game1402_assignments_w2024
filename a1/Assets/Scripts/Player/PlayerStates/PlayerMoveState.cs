using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    private PlayerControls player;

    public PlayerMoveState(PlayerControls player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        Debug.Log("Now entering Move State vroom!");
    }
}
