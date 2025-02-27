using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainAttackState : PlayerState
{
    protected int cntAtk = 0;
    protected float lastAtkTime = 0;
    protected int atkDir = 0;
    public PlayerMainAttackState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        atkDir = (int)Input.GetAxisRaw("Horizontal");
        if (atkDir == 0) atkDir = player.FacingDir;
        if (Time.time - lastAtkTime > player.atkWindowTime||cntAtk>2)
        {
            cntAtk = 0;
        }
        anim.SetInteger("cntAtk", cntAtk);
        player.currentAtk = player.originalAtk + player.increaseAtkValue * cntAtk;
        player.SetVelocity(player.atkForward[cntAtk].x * atkDir, player.atkForward[cntAtk].y);
    }

    public override void Exit()
    {
        base.Exit();
        player.currentAtk = player.originalAtk;
        cntAtk++;
        lastAtkTime = Time.time;
        player.StartCoroutine("BusyFor", .25f);
    }

    public override void Update()
    {
        base.Update();

        if (animFinshed)
        {
            stateMachine.ChangeState(player.idleState);
            return;
        }
    }

}
