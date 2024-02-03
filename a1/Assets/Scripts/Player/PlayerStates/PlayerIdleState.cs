using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    PlayerControls _player;

    readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    readonly int BoredIdlehash = Animator.StringToHash("IdleBored");

    float _crossFadeDuration = 0.1f;
    float _boredTimer = 15f;

    public PlayerIdleState(PlayerControls player)
    {
        this._player = player;
    }

    public void EnterState()
    {
        Debug.Log("Entering Idle State");
        _player.Animator.CrossFadeInFixedTime(LocomotionHash, _crossFadeDuration);
        _player.StartCoroutine(BoredAnim());
    }

    public void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }
    IEnumerator BoredAnim()
    {
        while (_player.PlayerStateMachine.CurrentState == _player.PlayerStateMachine._idleState)
        {
            _player.Animator.CrossFade(BoredIdlehash, _crossFadeDuration);
            yield return new WaitForSeconds(_boredTimer);
        }
    }
}
