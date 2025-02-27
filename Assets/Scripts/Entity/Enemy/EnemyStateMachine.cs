using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState curState;
    public void Init(EnemyState enemyState)
    {
        curState = enemyState;
        curState.Enter();
    }
    public void ChangeState(EnemyState enemyState)
    {
        curState.Exit();
        curState=enemyState;
        curState.Enter();
    }
}
