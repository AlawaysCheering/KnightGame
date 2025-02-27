using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : SkeletonState
{
    int attackDir;
    public SkeletonAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (player.position.x != skeleton.transform.position.x)
            attackDir = player.position.x - skeleton.transform.position.x > 0 ? 1 : -1;
        else attackDir = skeleton.FacingDir;
        skeleton.FilpController(attackDir);
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.lastAtackTime = Time.time;
        skeleton.AttackWindowCloase();
    }

    public override void Update()
    {
        base.Update();
        skeleton.SetVelocity(0, 0);
        if (animFinshed)
        {
            stateMachine.ChangeState(skeleton.moveState);
            return;
        }

    }
}
