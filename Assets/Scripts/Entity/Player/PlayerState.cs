using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerState : State
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    public float xInput;
    protected float yInput;

    public PlayerState(Player _player,PlayerStateMachine _stateMachine,string _animName)
    {
        player = _player;
        rb = player.rb;
        anim = player.anim;
        stateMachine = _stateMachine;
        animName = _animName;
    }
    public override void Update()
    {
        base.Update();
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxis("Vertical");
        anim.SetFloat("yVelocity",rb.velocity.y);

    }

}
