using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundState
{
    public SkeletonMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
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
        if(!skeleton.isGround()||skeleton.isWallTouched())
        {
            skeleton.Flip();
            stateMachine.ChangeState(skeleton.idleState);
            return;
        }
        skeleton.SetVelocity(skeleton.moveSpeed*skeleton.FacingDir,rb.velocity.y);
    }
}
