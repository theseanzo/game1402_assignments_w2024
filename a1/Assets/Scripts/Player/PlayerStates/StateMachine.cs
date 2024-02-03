using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    public IPlayerState CurrentState { get; private set; }

    // Reference to State Objects.
    public PlayerIdleState _idleState;
    public PlayerMoveState _moveState;
    public PlayerJumpState _jumpState;

    // Notification event.
    public event Action<IPlayerState> _stateChanged;

    // Constructor for each state to pass through player controller.
    public StateMachine(PlayerControls player)
    {
        this._idleState = new PlayerIdleState(player);
        this._moveState = new PlayerMoveState(player);
        this._jumpState =  new PlayerJumpState(player);
    }

    public void Init(IPlayerState state)
    {
        CurrentState = state;
        state.EnterState();

        // Notify other objects that the state has changed.
        _stateChanged?.Invoke(state);
    }

    public void TransitionTo(IPlayerState nextState)
    {
        CurrentState.ExitState();
        CurrentState = nextState;
        nextState.EnterState();

        // Notifies other objects of a state change.
        _stateChanged?.Invoke(nextState);
    }

    public void Update()
    {
        if (CurrentState != null)
            CurrentState.Update();
    }
}
