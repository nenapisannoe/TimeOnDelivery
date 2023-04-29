using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefabs;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private bool _shouldSpawnPeriodically = true;
    [SerializeField] private float _spawningDelayInSeconds = 2.0f;

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
        _traficController.RedLight.AddListener(StopSpawning);
        _traficController.GreenLight.AddListener(StartSpawning);
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
        var index = Random.Range(0, _carPrefabs.Length);
        var prefab = _carPrefabs[index];

        GameObject carObject = Instantiate(prefab, _spawnPosition);
        CarScript carScript = carObject.GetComponent<CarScript>();
        if (carScript != null)
        {
            ConfigureCar(carScript);
        }
    }

    private void ConfigureCar(CarScript carScript)
    {
        if (_traficController.Green)
        {
            carScript.OnGreenLight();
        }
        else
        {
            carScript.OnRedLight();
        }

        _traficController.GreenLight.AddListener(carScript.OnGreenLight);
        _traficController.RedLight.AddListener(carScript.OnRedLight);
    }
}
