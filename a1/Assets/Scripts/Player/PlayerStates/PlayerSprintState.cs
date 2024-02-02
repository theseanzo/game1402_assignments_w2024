using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : IPlayerState
{
    private PlayerControls player;

    public PlayerSprintState(PlayerControls player)
    {
        this.player = player;
    }

}
