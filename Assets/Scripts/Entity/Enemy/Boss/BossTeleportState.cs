using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleportState : BossState
{
    
    public BossTeleportState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if (animFinshed)
        {
            stateMachine.ChangeState(boss.idleState);
        }

    }
    public override void Exit()
    {
        base.Exit();
    }

}
