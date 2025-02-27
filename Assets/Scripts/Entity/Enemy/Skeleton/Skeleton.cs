using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    #region ×´Ì¬»ú
    public SkeletonIdleState idleState;
    public SkeletonMoveState moveState;
    public SkeletonBattleState battleState;
    public SkeletonAttackState attackState;
    public SkeletonHitState hitState;
    public SkeletonDeadState deadState;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        idleState = new SkeletonIdleState(this,stateMachine,"Idle");
        moveState = new SkeletonMoveState(this, stateMachine, "Move");
        battleState = new SkeletonBattleState(this, stateMachine,"Move");
        attackState = new SkeletonAttackState(this, stateMachine, "Attack");
        hitState = new SkeletonHitState(this, stateMachine, "Hit");
        deadState = new SkeletonDeadState(this, stateMachine,"Dead");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Init(idleState);
    }

    public override void Damage(int hurtValue)
    {
        base.Damage(hurtValue);
        if(currentHp>0)
            stateMachine.ChangeState(hitState);
        else
        {
            Dead();
        }
    }
    protected override void Dead()
    {
        if (isDead) return;
        isDead = true;
        stateMachine.ChangeState(deadState);
    }
}
