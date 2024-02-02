using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public void EnterState() {}
    public void Update() {}
    public void ExitState() {}
}
