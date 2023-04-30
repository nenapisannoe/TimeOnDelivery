using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModelCreator : MonoBehaviour
{
    [SerializeField] GameObject[] _carModelPrefabs;

    private void Start()
    {
        var carPrefab = _carModelPrefabs[Random.Range(0, _carModelPrefabs.Length)];
        var car = Instantiate(carPrefab, transform);
        car.transform.Rotate(Vector3.up, -90);
    }
}
