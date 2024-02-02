using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    PlayerControls _player;

    readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    readonly int BoredIdlehash = Animator.StringToHash("IdleBored");

    float _crossFadeDuration = 0.1f;

    public PlayerIdleState(PlayerControls player)
    {
        this._player = player;
    }

    public void EnterState()
    {
        Debug.Log("Entering Idle State");
        _player.StartCoroutine(BoredAnim());
    }

    public void Update()
    {
        // 
    }

    public void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }
    IEnumerator BoredAnim()
    {
        while (true)
        {
            _player.Animator.CrossFadeInFixedTime(BoredIdlehash, _crossFadeDuration);
            yield return new WaitForSeconds(7f);
        }
    }
}
