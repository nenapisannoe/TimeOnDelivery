using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossWalkController : MonoBehaviour
{
    [SerializeField] TraficController _traficController;
    [SerializeField] private Collider[] _playerStopers;

    [SerializeField] private Light[] _pedestrianGreenLights;
    [SerializeField] private Light[] _pedestrianRedLights;

    private void Start()
    {
        if (_traficController.PedestrianGreen)
        {
            OnGreenLight();
        }
        else
        {
            OnRedLight();
        }
        _traficController.PedestrianRedLight.AddListener(OnRedLight);
        _traficController.PedestrianGreenLight.AddListener(OnGreenLight);
    }

    public void OnGreenLight()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = false;
        }

        foreach (Light light in _pedestrianGreenLights)
        {
            light.enabled = true;
        }

        foreach (Light light in _pedestrianRedLights)
        {
            light.enabled = false;
        }
    }

    public void OnRedLight()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = true;
        }

        foreach (Light light in _pedestrianRedLights)
        {
            light.enabled = true;
        }

        foreach (Light light in _pedestrianGreenLights)
        {
            light.enabled = false;
        }
    }
}
