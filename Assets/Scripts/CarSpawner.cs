using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefabs;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private bool _shouldSpawnPeriodically = true;
    [SerializeField] private float _spawningDelayInSeconds = 2.0f;

    public void StartSpawning()
    {
        _shouldSpawnPeriodically = true;
    }

    public void StopSpawning()
    {
        _shouldSpawnPeriodically = false;
    }

    public float SpawningDelayInSeconds
    {
        get { return _spawningDelayInSeconds; }
        set
        {
            if (value > 0.0f)
                _spawningDelayInSeconds = value;
        }
    }

    void Start()
    {
        if (_shouldSpawnPeriodically)
        {
            StartCoroutine(SpawnThenDelay());
        }
    }

    IEnumerator SpawnThenDelay()
    {
        while (_shouldSpawnPeriodically) 
        {
            Spawn();

            yield return new WaitForSeconds(_spawningDelayInSeconds);
        }
        
    }

    public void Spawn()
    {
        var index = Random.Range(0, _carPrefabs.Length);
        var prefab = _carPrefabs[index];

        Instantiate(prefab, _spawnPosition);
    }
}
