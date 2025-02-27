using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState :State
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName)
    {
        this.enemy = _enemy;
        rb = enemy.rb;
        anim = enemy.anim;
        this.stateMachine = _stateMachine;
        this.animName = _animName;
    }

}
