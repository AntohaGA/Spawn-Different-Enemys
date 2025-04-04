using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyTypeA : Enemy
{
    private IEnumerator _moveCoroutine;

    private float _minPositionToTarget = 1;

    public override event Action<Enemy> Killed;

    private void Awake()
    {
        Speed = 4;
    }

    private void OnDisable()
    {
        StopCoroutine(_moveCoroutine);
    }

    public override void FollowByTarget(TargetForEnemy target)
    {
        _moveCoroutine = FollowToTarget(target);
        StartCoroutine(_moveCoroutine);
    }

    protected IEnumerator FollowToTarget(TargetForEnemy target)
    {
        while (Vector3.Distance(transform.position, target.GetPosition()) > _minPositionToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.GetPosition(), Speed * Time.deltaTime);

            yield return null;
        }

        Killed?.Invoke(this);
    }
}