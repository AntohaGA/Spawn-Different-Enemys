using UnityEngine;
using UnityEngine.Pool;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private int _poolCapacity = 10;
    private int _poolMaxCount = 1000;

    private ObjectPool<Enemy> _poolEnemy;

    private void Awake()
    {
        _poolEnemy = new ObjectPool<Enemy>(CreateEnemy, TakeFromPool, ReturnToPool,
                                            DestroyEnemy, true, _poolCapacity, _poolMaxCount);
    }

    public Enemy GetEnemy()
    {
        return _poolEnemy.Get();
    }

    public void KillEnemy(Enemy enemy)
    {
        _poolEnemy.Release(enemy);
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_enemyPrefab);
    }

    private void TakeFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void ReturnToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void DestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}