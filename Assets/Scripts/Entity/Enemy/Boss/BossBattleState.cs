using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleState : BossState
{

    protected int batteDir;
    public BossBattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
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
        if (!boss.CanFindPlayer() || boss.isWallTouched())
        {
            stateMachine.ChangeState(boss.idleState);
            return;
        }
        if (Vector3.Distance(player.position, boss.transform.position) <= boss.atackDistance && Time.time >= boss.lastAtackTime + boss.attackCoolDown)
        {
            stateMachine.ChangeState(boss.attackState);
            return;
        }
        if (Mathf.Abs(player.position.x - boss.transform.position.x) >= 1)
            batteDir = player.position.x - boss.transform.position.x > 0 ? 1 : -1;
        else batteDir = boss.FacingDir;
        boss.SetVelocity(boss.battleSpeed * batteDir, rb.velocity.y);
    }
}
