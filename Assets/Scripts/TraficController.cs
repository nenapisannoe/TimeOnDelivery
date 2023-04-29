using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TraficController : MonoBehaviour
{
    public UnityEvent CarGreenLight { get; private set; } = new UnityEvent();
    public UnityEvent CarRedLight { get; private set; } = new UnityEvent();

    public UnityEvent PedestrianGreenLight { get; private set; } = new UnityEvent();
    public UnityEvent PedestrianRedLight { get; private set; } = new UnityEvent();

    [SerializeField] private bool _pedestrianGreen = false;

    [SerializeField] private float _greenLightSeconds = 10;
    [SerializeField] private float _redLightSeconds = 10;

    public bool PedestrianGreen { get { return _pedestrianGreen; } }

    public bool CarGreen { get { return !_pedestrianGreen; } }

    void Start()
    {
        StartCoroutine(SwitchLightPeriodically());
    }

    private IEnumerator SwitchLightPeriodically()
    {
        while (true)
        {
            SwitchLight();

            yield return new WaitForSeconds(GetCurrentLightLatency());

            _pedestrianGreen = !_pedestrianGreen;
        }
    }

    private void SwitchLight()
    {
        if (_pedestrianGreen)
        {
            CarRedLight.Invoke();
            PedestrianGreenLight.Invoke();
        } else
        {
            CarGreenLight.Invoke();
            PedestrianRedLight.Invoke();
        }
    }

    private float GetCurrentLightLatency()
    {
        return _pedestrianGreen ? _greenLightSeconds : _redLightSeconds;
    }
}
