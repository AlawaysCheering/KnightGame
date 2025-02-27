using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    Boss boss;
    EntityFx entityFx;
    private void Awake()
    {
        boss = GetComponentInParent<Boss>();
        entityFx=GetComponent<EntityFx>();  
    }
    public void SetBossPos() => boss.FindPositon();
    public void AnimationFinshed()=> boss.EnemyAnimationFinshed();
    public void Attacktrigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(boss.AttackCheck.position, boss.AttackCheckRadius, 1 << LayerMask.NameToLayer("Player"));
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage(boss.atk);
        }

    }
    public void AttackWindowOpen()
    {
        boss.AttackWindowOpen();
    }
    public void AttackWindowClose()
    {
        boss.AttackWindowCloase();
    }
    public void SetBusyTrue() => boss.busy = true;
    public void SetBusyFalse() => boss.busy = false;

}
