using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(player.counterAttackState);
            return;
        }
        if ((player.isWallTouched() && ((xInput > 0 && player.FacingDir > 0) || (xInput < 0 && player.FacingDir < 0))))
        {
            return;
        }
        if (xInput != 0&&!player.isBusy)
        {
            stateMachine.ChangeState(player.moveState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
