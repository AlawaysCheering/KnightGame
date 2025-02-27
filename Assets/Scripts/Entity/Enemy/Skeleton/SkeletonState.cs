using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonState : EnemyState
{
    protected Skeleton skeleton;

    protected Transform player;
    public SkeletonState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animName) : base(_enemy, _stateMachine, _animName)
    {
        skeleton = _enemy as Skeleton;
        player = GameObject.Find("Player").GetComponent<Player>().transform;
    }
}
