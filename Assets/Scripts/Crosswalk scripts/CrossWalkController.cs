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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !_traficController.PedestrianGreen)
        {
            LetPlayerGo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !_traficController.PedestrianGreen)
        {
            StartCoroutine(StopPlayerFromGoingAfterWait());
        }
    }

    public void OnGreenLight()
    {
        LetPlayerGo();

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
        StopPlayerFromGoing();

        foreach (Light light in _pedestrianRedLights)
        {
            light.enabled = true;
        }

        foreach (Light light in _pedestrianGreenLights)
        {
            light.enabled = false;
        }
    }

    private void LetPlayerGo()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = false;
        }
    }

    private IEnumerator StopPlayerFromGoingAfterWait()
    {
        yield return new WaitForSeconds(0.7f);

        StopPlayerFromGoing();
    }

    private void StopPlayerFromGoing()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = true;
        }
    }
}
