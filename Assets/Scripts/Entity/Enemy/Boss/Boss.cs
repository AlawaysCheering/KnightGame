using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    #region 长时间找不到player就传送
    public float lastFindPlayerTime = -1;
    public float NeedTelePortTime = 3;
    public bool busy = false;
    Player player;
    #endregion
    #region 状态
    public BossIdleState idleState { get; private set; }
    public BossBattleState battleState { get; private set; }
    public BossAttackState attackState { get; private set; }
    public BossDeadState deadState { get; private set; }
    public BossSpellCastState spellCastState { get; private set; }
    public BossTeleportState teleportState { get; private set;}
    public BossHitState hitState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.Find("Player").GetComponent<Player>();
        stateMachine = new EnemyStateMachine();
        idleState = new BossIdleState(this, stateMachine,"Idle");
        battleState = new BossBattleState(this, stateMachine, "Move");
        attackState = new BossAttackState(this, stateMachine, "Attack");
        deadState = new BossDeadState(this, stateMachine, "Dead");
        spellCastState = new BossSpellCastState(this, stateMachine, "SpellCast");
        teleportState = new BossTeleportState(this, stateMachine, "Teleport");
        hitState = new BossHitState(this, stateMachine, "Hit");
    }
    protected override void Update()
    {
        base.Update();
        CanFindPlayer();
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Init(idleState);
    }
    public override void Damage(int hurtValue)
    {
        base.Damage(hurtValue);
        if (currentHp > 0&&player.isConterATK)
            stateMachine.ChangeState(hitState);
        else if(currentHp<=0)
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
    private RaycastHit2D GroundBelow()=> Physics2D.Raycast(transform.position, Vector2.down,100,1<<LayerMask.NameToLayer("Ground"));

    public void FindPositon()
    {
        transform.position = player.lastSecondPos.Peek();
    }
    public bool CanFindPlayer()
    {
        if(player!=null&&Vector2.Distance(player.transform.position, transform.position)<=findPlayerDistance&&
            Mathf.Abs(player.transform.position.y - transform.position.y) < 2.5f)
        {
            lastFindPlayerTime = Time.time;
            return true;
        }
        return false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - GroundBelow().distance));
    }

}
