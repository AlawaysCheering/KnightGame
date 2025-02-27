using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    public void AnimationFinsh()
    {
        player.PlayerAnimationFinshed();
    }
    public void Attacktrigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.AttackCheck.position,player.AttackCheckRadius,1<<LayerMask.NameToLayer("Enemy")|1<<LayerMask.NameToLayer("Destruct"));
        foreach(Collider2D hit in hits)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                Vector2 dir = enemy.knockedDistance;
                if (player.transform.position.x > enemy.transform.position.x)
                {
                    dir.x = -enemy.knockedDistance.x;
                }
                enemy.Damage(dir,player.currentAtk);
            }
            if (hit.GetComponent<Destructble>() != null)
            {
                Destructble destructble = hit.GetComponent<Destructble>();
                destructble.DestroyObject();
            }
        }
        Audio.Instance.PlaySFX(0);
    }
}
