using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected string animName;
    protected float stateTimer;
    protected bool animFinshed;
    protected Rigidbody2D rb;
    protected Animator anim;
    public virtual void Enter()
    {
        anim.SetBool(animName, true);
        animFinshed = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit() {
        anim.SetBool(animName, false);
    }
    public virtual void AnimationFinshed()
    {
        animFinshed = true;
    }
}
