using UnityEngine;

[RequireComponent(typeof(PoolEnemy))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private TargetForEnemy _targetForEnemy;

    private PoolEnemy _poolEnemy;

    private void Awake()
    {
        _poolEnemy = GetComponent<PoolEnemy>();
    }

    public void SpawnEnemy()
    {
        Enemy enemy = _poolEnemy.GetEnemy();
        enemy.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        enemy.FollowByTarget(_targetForEnemy);
        enemy.Killed += KillEnemy;
    }

    private void KillEnemy(Enemy enemy)
    {
        enemy.Killed -= KillEnemy;
        _poolEnemy.KillEnemy(enemy);
    }
}