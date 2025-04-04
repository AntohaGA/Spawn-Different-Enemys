using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float Speed;

    public abstract event Action<Enemy> Killed;

    public abstract void FollowByTarget(TargetForEnemy target);
}