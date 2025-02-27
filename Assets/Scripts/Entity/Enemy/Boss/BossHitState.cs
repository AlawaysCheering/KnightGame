using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitState : BossState
{
    public BossHitState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        boss.entityFx.OnHurtStart();
        stateTimer = boss.hitDuration;

    }

    public override void Exit()
    {
        base.Exit();
        boss.entityFx.OnHurtEnd();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(boss.idleState);
        }
    }
}
