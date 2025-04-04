using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChooser : MonoBehaviour
{
    private const int DelaySpawn = 1;

    [SerializeField] private List<EnemySpawner> _spawners;

    private IEnumerator _spawnCoroutine;
    private WaitForSeconds _delayEnemySpawn;

    private bool _isContinue;

    private void Awake()
    {
        _isContinue = true;
        _spawnCoroutine = SpawnDelay();
        _delayEnemySpawn = new WaitForSeconds(DelaySpawn);
    }

    private void OnEnable()
    {
        StartCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnDelay()
    {
        while (_isContinue)
        {
            yield return _delayEnemySpawn;

            _spawners[Random.Range(0, _spawners.Count)].SpawnEnemy();
        }
    }
}