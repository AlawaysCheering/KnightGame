using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellCastState : BossState
{
    public BossSpellCastState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        if(stateTimer < 0)
        {
            stateMachine.ChangeState(boss.idleState);
        }

    }
}
