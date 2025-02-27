using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animName) : base(_player, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.counterTime;
        player.currentAtk = player.originalAtk + 10;
        anim.SetBool("successCounter", false);
        player.SetVelocity(0, 0);
        player.isConterATK = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.currentAtk = player.originalAtk;
        anim.SetBool("successCounter", false);
        player.isConterATK = false;
    }
    bool f = false;
    public override void Update()
    {
        base.Update();
        if (stateTimer < 0||animFinshed) {
            stateMachine.ChangeState(player.idleState);
            return;
        }
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy.CanStudded())
                {
                    anim.SetBool("successCounter", true);
                    stateTimer = 10;
                    Vector2 dir = enemy.knockedDistance;
                    if (player.transform.position.x > enemy.transform.position.x)
                    {
                        dir.x = -enemy.knockedDistance.x;
                    }
                    enemy.Damage(dir,player.currentAtk);
                    f = true;
                }
            }
        }
        if (f)
        {
            Audio.Instance.PlaySFX(1);
            f = false;
        }
    }
}
