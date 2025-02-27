using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSliderState : PlayerState
{
    public PlayerWallSliderState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
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
        if (yInput < 0)
            player.SetVelocity(0, -player.wallSliderSpeed*2);
        else player.SetVelocity(0,-player.wallSliderSpeed);
        if ((xInput>0&&player.FacingDir<0)||(xInput<0&&player.FacingDir>0))
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        if(player.isGround())
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpSate);
        }
    }
}
