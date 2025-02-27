using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : BossState
{
    public BossDeadState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocity(0, 0);
    }
    public override void Update()
    {
        base.Update();
        if (animFinshed)
        {
            Exit();
        }
    }
    public override void Exit()
    {
        base.Exit();
        anim.SetBool(animName, false);
        GameObject obj = Resources.Load<GameObject>("Prefab/ChuanSongMen");
        GameObject.Instantiate(obj,boss.transform.position,Quaternion.identity).GetComponent<ChuanSongMen>().SetSceneName("Win");

        GameObject.Destroy(boss.gameObject);
    }
}
