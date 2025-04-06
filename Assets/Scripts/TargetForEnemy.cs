using System.Collections;
using UnityEngine;

public class TargetForEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    [SerializeField] private int _speed;

    private bool isContinue;

    private IEnumerator _moveCoroutine;

    private void Awake()
    {
        _moveCoroutine = MoveBetweenPoints();
    }

    private void OnEnable()
    {
        isContinue = true;
        StartCoroutine(_moveCoroutine);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private IEnumerator MoveBetweenPoints()
    {
        int currentPoint = 0;

        while (isContinue)
        {
            if(transform.position == _wayPoints[currentPoint].position)
            {
                currentPoint= (currentPoint + 1) % _wayPoints.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[currentPoint].position, _speed * Time.deltaTime);

            yield return null;
        }
    }
}