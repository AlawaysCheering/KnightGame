using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = SkillManager.Instance.dash.skillDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);

    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashPower * player.dashFacingDir, 0);
        if (player.isWallTouched() && !player.isGround()) {
            stateMachine.ChangeState(player.wallSliderState);
            return;
        }
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
    }

}
