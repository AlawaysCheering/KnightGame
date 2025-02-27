using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : EnemyState
{
    protected Boss boss;
    protected Transform player;
    public BossState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
        boss = _enemy as Boss;
        player = GameObject.Find("Player").GetComponent<Player>().transform;
    }

}
