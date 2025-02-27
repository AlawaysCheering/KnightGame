using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : Entity
{
    #region ²ÎÊý
    public int atk;
    public float moveSpeed = 5;
    public float idleTime = 0;
    public float battleSpeed = 8;
    public float findPlayerDistance = 5;
    public float atackDistance;
    public float attackCoolDown = .5f;
    public float lastAtackTime = 0;
    public Transform findPlayerCheck;
    private bool isKoncked=false;
    public Vector2 knockedDistance;
    [SerializeField] private float knockedDuration;
    [SerializeField] private Transform attackWindow;
    private bool canStudded = false;
    public float hitDuration;

    #endregion
    protected EnemyStateMachine stateMachine;
    public virtual void EnemyAnimationFinshed()
    {
        stateMachine.curState.AnimationFinshed();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.curState.Update();
    }
    public void Damage(Vector2 dir,int hurtValue)
    {
        if (isDead) return;
        Damage(hurtValue);
        StartCoroutine("BeKoncked", dir);
    }
    IEnumerator BeKoncked(Vector2 konckedDir)
    {
        isKoncked = true;
        rb.AddForce(konckedDir, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockedDuration);
        isKoncked = false;
    }
    public virtual RaycastHit2D isPlayerFind() => Physics2D.Raycast(findPlayerCheck.position, Vector2.right * FacingDir, findPlayerDistance, 1 << LayerMask.NameToLayer("Player"));
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance*FacingDir, WallCheck.position.y));
        Gizmos.DrawLine(findPlayerCheck.position, new Vector3(findPlayerCheck.position.x + findPlayerDistance*FacingDir, findPlayerCheck.position.y));
    }
    public override void SetVelocity(float x, float y)
    {
        if (isKoncked) return;
        rb.velocity = new Vector2(x, y);
        FilpController(x);
    }
    public void AttackWindowOpen()
    {
        canStudded = true;
        attackWindow.gameObject.SetActive(true);
    }
    public void AttackWindowCloase()
    {
        canStudded = false;
        attackWindow.gameObject.SetActive(false);
    }
    public bool CanStudded()
    {
        if (canStudded)
        {
            canStudded = false;
            return true;
        }
        return false;
    }

}
