using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHitState : SkeletonState
{
    public SkeletonHitState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        skeleton.entityFx.OnHurtStart();
        stateTimer = skeleton.hitDuration;

    }

    public override void Exit()
    {
        base.Exit();
        skeleton.entityFx.OnHurtEnd();  
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
}
