using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        boss.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (boss.CanFindPlayer())
            stateMachine.ChangeState(boss.battleState);
        //if (Time.time-boss.lastFindPlayerTime>boss.NeedTelePortTime||boss.lastFindPlayerTime==-1)
        //{
        //    stateMachine.ChangeState(boss.teleportState);
        //}
        if (!boss.CanFindPlayer()&& Time.time - boss.lastFindPlayerTime > boss.NeedTelePortTime &&!boss.busy)
        {
            stateMachine.ChangeState(boss.teleportState);
        }
    }
}
