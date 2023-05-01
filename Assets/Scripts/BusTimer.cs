using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusTimer : MonoBehaviour
{
    [SerializeField] float timeLeft = 7.0f;
    [SerializeField] float timeStop = 0.7f;
    [SerializeField] float timePeriod = 15.0f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool busStop = false;

    void Start()
    {
        busStop = false;
    }
    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (!busStop) DisplayTime(timeLeft);
        if (timeLeft <= 0)
        {
            if (busStop)
            {
                timeLeft = timePeriod;
                busStop = !busStop;
            }
            else
            {
                busStop = true;
                timeLeft = timeStop;
            }
        }
     
    }

    void DisplayTime(float timeToDisplay)
    {
        timerText.text = timeLeft.ToString("0");
    }

}
