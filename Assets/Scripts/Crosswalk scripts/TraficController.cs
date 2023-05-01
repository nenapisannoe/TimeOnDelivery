using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TraficController : MonoBehaviour
{
    public UnityEvent CarGreenLight { get; private set; } = new UnityEvent();
    public UnityEvent CarRedLight { get; private set; } = new UnityEvent();

    public UnityEvent PedestrianGreenLight { get; private set; } = new UnityEvent();
    public UnityEvent PedestrianRedLight { get; private set; } = new UnityEvent();

    [SerializeField] private bool _pedestrianGreen = false;

    [SerializeField] private float _greenLightSeconds = 10;
    [SerializeField] private float _redLightSeconds = 10;

    [SerializeField] private TextMeshProUGUI _timerText;

    private float _timeLeft;

    public bool PedestrianGreen { get { return _pedestrianGreen; } }

    public bool CarGreen { get { return !_pedestrianGreen; } }

    void Start()
    {
        _timeLeft = GetCurrentLightLatency();
        UpdateTimerTextColor();
        StartCoroutine(SwitchLightPeriodically());
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        DisplayTime();
    }

    private void DisplayTime()
    {
        _timerText.text = _timeLeft.ToString("0");
    }

    private void UpdateTimerTextColor()
    {
        if (_pedestrianGreen)
            SetTimerTextGreen();
        else
            SetTimerTextRed();
    }

    private void SetTimerTextGreen()
    {
        _timerText.color = Color.green;
    }

    private void SetTimerTextRed()
    {
        _timerText.color = Color.red;
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
        _timeLeft = GetCurrentLightLatency();
        UpdateTimerTextColor();

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
