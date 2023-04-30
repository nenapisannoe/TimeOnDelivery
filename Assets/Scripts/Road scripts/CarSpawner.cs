using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Cars to spawn
    [SerializeField] private GameObject _carPrefab;
    
    // Car pathes setup
    [SerializeField] private Path[] _carPathes;
    [SerializeField] private bool _isCarPathesLooped;

    // Spawning configuration
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private bool _shouldSpawnPeriodically = true;
    [SerializeField] private float _spawningDelayInSeconds = 2.0f;

    // Trafic controller which controls car movement and spawning by trafic light evenets
    [SerializeField] private TraficController _traficController;

    private bool _delayEnded = true;

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
        if (_traficController.CarGreen)
        {
            StartSpawning();
        } else
        {
            StopSpawning();
        }
        _traficController.CarRedLight.AddListener(StopSpawning);
        _traficController.CarGreenLight.AddListener(StartSpawning);
    }

    private void Update()
    {
        if (_shouldSpawnPeriodically && _delayEnded)
        {
            StartCoroutine(SpawnThenDelay());
        }
    }

    IEnumerator SpawnThenDelay()
    {
        Spawn();

        _delayEnded = false;

        yield return new WaitForSeconds(_spawningDelayInSeconds);

        _delayEnded = true;
    }

    public void Spawn()
    {
        GameObject carObject = Instantiate(_carPrefab, _spawnPosition);
        CarScript carScript = carObject.GetComponent<CarScript>();
        if (carScript != null)
        {
            ConfigureCar(carScript);
        }
    }

    private void ConfigureCar(CarScript carScript)
    {
        //_traficController.CarGreenLight.AddListener(carScript.OnGreenLight);
        //_traficController.CarRedLight.AddListener(carScript.OnRedLight);

        carScript.SetPaths(_carPathes, _isCarPathesLooped);
    }
}
