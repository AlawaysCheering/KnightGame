using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0);
    }
    public override void Update()
    {
        base.Update();
        if (animFinshed)
        {
            Exit();
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
