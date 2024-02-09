using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IPlayerState
{
    PlayerControls _player;

    readonly int _jumpHash = Animator.StringToHash("Jumping");

    float _crossFadeTime = 0.1f;

    public PlayerJumpState(PlayerControls player)
    {
        this._player = player;
    }

    public void EnterState()
    {
        _player.Animator.CrossFadeInFixedTime(_jumpHash, _crossFadeTime);
        Jump();
    }

    public void Update()
    {
    }

    public void ExitState()
    {
    }

    void Jump()
    {
        Vector3 jumpVelocity = _player.Rb.velocity;
        jumpVelocity.y = _player.JumpForce;
        _player.Rb.velocity = jumpVelocity;
    }
}
