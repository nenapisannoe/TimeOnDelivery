using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TraficController : MonoBehaviour
{
    public UnityEvent CarGreenLight { get; private set; } = new UnityEvent();
    public UnityEvent CarRedLight { get; private set; } = new UnityEvent();

    [SerializeField] private bool _green = true;

    [SerializeField] private float _greenLightSeconds = 10;
    [SerializeField] private float _redLightSeconds = 10;

    public bool Green { get { return _green; } }

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

            _green = !_green;
        }
    }

    private void SwitchLight()
    {
        if (_green)
        {
            CarGreenLight.Invoke();
        } else
        {
            CarRedLight.Invoke();
        }
    }

    private float GetCurrentLightLatency()
    {
        return _green ? _greenLightSeconds : _redLightSeconds;
    }
}
