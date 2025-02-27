using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Entity
{
    #region 角色参数
    public bool isConterATK = false;
    public int originalAtk = 15;
    public int currentAtk;
    public int increaseAtkValue = 5;
    public Vector2[] atkForward;
    public bool isBusy;
    public float moveSpeed=8;
    public float jumpForce = 12;
    public float dashPower = 20;
    public float dashTimer;
    public int dashFacingDir;
    public float wallSliderSpeed = 1;
    public float wallJumpForceY = 15;
    public float wallJumpForceX = 5;
    public float wallJumpDuration = 0.5f;
    public float atkWindowTime;
    public float counterTime = 0.5f;
    public Queue<Vector3> lastSecondPos=new Queue<Vector3>();
    private float lastPosTimer = 0;
    #endregion



    #region 状态机
    public PlayerStateMachine stateMachine;
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerAirState airState;
    public PlayerDashState dashState;
    public PlayerWallSliderState wallSliderState;
    public PlayerWallJumpSate wallJumpSate;
    public PlayerMainAttackState mainAttackState;
    public PlayerCounterAttackState counterAttackState;
    public PlayerDeadState deadState;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        deadState = new PlayerDeadState(this, stateMachine, "Dead");
        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSliderState = new PlayerWallSliderState(this, stateMachine, "wallSlider");
        wallJumpSate = new PlayerWallJumpSate(this, stateMachine, "Jump");
        mainAttackState = new PlayerMainAttackState(this, stateMachine, "Attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "Counter");
        DontDestroyOnLoad(gameObject);
    }
    protected override void Dead()
    {
        base.Dead();
        stateMachine.ChangeState(deadState);

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "BeginScene")
        {
            Destroy(gameObject);
        }
    }
    protected override void Start()
    {
        base.Start();
        currentAtk = originalAtk;
        stateMachine.Init(idleState);
        lastSecondPos.Enqueue(transform.position);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.curState.Update();
        DashController();
        lastPosTimer += Time.deltaTime;
        if (lastPosTimer > 0.5f)
        {
            lastSecondPos.Enqueue(transform.position);
            lastPosTimer = 0;
        }
        while(lastSecondPos.Count > 3)
        {
            lastSecondPos.Dequeue();
        }

    }
    IEnumerator BusyFor(float second)
    {
        isBusy = true;
        yield return new WaitForSeconds(second);
        isBusy = false;
    }
    public void PlayerAnimationFinshed() => stateMachine.curState.AnimationFinshed();
    private void DashController()
    {
        if ( Input.GetKeyDown(KeyCode.LeftShift) && !isWallTouched()&& SkillManager.Instance.dash.CanUseSkill())
        {
            dashFacingDir = (int)Input.GetAxisRaw("Horizontal");
            if (dashFacingDir == 0) dashFacingDir = FacingDir;
            stateMachine.ChangeState(dashState);
        }
    }

}
