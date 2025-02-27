using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : SkeletonState
{
    protected int batteDir;
    public SkeletonBattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!skeleton.isPlayerFind()|| !skeleton.isGround() || skeleton.isWallTouched())
        {
            stateMachine.ChangeState(skeleton.idleState);
            return;
        }
        if(Vector3.Distance(player.position,skeleton.transform.position)<=skeleton.atackDistance&& Time.time >= skeleton.lastAtackTime + skeleton.attackCoolDown) {
                stateMachine.ChangeState(skeleton.attackState);
            return;
        }
        if (Mathf.Abs(player.position.x-skeleton.transform.position.x)>=1)
            batteDir = player.position.x - skeleton.transform.position.x > 0 ? 1 : -1;
        else batteDir = skeleton.FacingDir;
        skeleton.SetVelocity(skeleton.battleSpeed * batteDir, rb.velocity.y);
    }
}
