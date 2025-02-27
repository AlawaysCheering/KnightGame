using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        if(player.isWallTouched()&& ((xInput > 0 && player.FacingDir > 0) || (xInput < 0 && player.FacingDir < 0)))
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        player.SetVelocity(xInput*player.moveSpeed, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
    }
}
