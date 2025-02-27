using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : SkeletonState
{
    public SkeletonDeadState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        skeleton.SetVelocity(0, 0);
    }
    public override void Update()
    {
        base.Update();
        if(animFinshed)
        {
            Exit();
        }
    }
    public override void Exit()
    {
        base.Exit();
        GameObject.Destroy(skeleton.gameObject);
    }
}
