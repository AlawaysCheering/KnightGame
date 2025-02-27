using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    int attackDir;
    public BossAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        if (player.position.x != boss.transform.position.x)
            attackDir = player.position.x - boss.transform.position.x > 0 ? 1 : -1;
        else attackDir = boss.FacingDir;
        boss.FilpController(attackDir);
    }

    public override void Exit()
    {
        base.Exit();
        boss.lastAtackTime = Time.time;
        boss.AttackWindowCloase();
    }

    public override void Update()
    {
        base.Update();
        boss.SetVelocity(0, 0);
        if (animFinshed)
        {
            stateMachine.ChangeState(boss.battleState);
            return;
        }

    }
}
