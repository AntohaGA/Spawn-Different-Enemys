using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IEnumerator _moveCoroutine;

    private float _minPositionToTarget = 1.5f;

    public event Action<Enemy> Killed;

    public void FollowByTarget(TargetForEnemy target)
    {
        _moveCoroutine = FollowToTarget(target);
        StartCoroutine(_moveCoroutine);
    }

    protected IEnumerator FollowToTarget(TargetForEnemy target)
    {
        while ( ((transform.position - target.GetPosition()).sqrMagnitude) > _minPositionToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.GetPosition(), _speed * Time.deltaTime);

            yield return null;
        }

        Killed?.Invoke(this);
    }
}