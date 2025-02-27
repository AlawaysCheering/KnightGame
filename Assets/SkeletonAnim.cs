using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{
    Skeleton skeleton;
    private void Awake()
    {
        skeleton = GetComponentInParent<Skeleton>();
    }
    public void AnimationFinshed()
    {
        skeleton.EnemyAnimationFinshed();
    }
    public void Attacktrigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(skeleton.AttackCheck.position, skeleton.AttackCheckRadius, 1 << LayerMask.NameToLayer("Player"));
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage(skeleton.atk);
        }

    }
    public void AttackWindowOpen()
    {
       skeleton.AttackWindowOpen();
    }
    public void AttackWindowClose()
    {
        skeleton.AttackWindowCloase();
    }
}
