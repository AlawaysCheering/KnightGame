using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState curState;
    public void Init(PlayerState _curState)
    {
        curState = _curState;
        curState.Enter();
    }
    public void ChangeState(PlayerState _curState)
    {
        curState.Exit();
        curState=_curState;
        curState.Enter();
    }
}
