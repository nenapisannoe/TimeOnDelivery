using System.Collections;
using System.Collections.Generic;
using Unity.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float currentTime = 0.0f;
    [SerializeField] private Text timerText;
    private bool timeOver = false;
    private DeliveryManager _deliveryManager;

    void Start()
    {
        _deliveryManager = FindObjectOfType<DeliveryManager>();
        timeOver = false;
    }
    void Update()
    {
        if (!timeOver)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }
    
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timeOver = true;
    }

    public float GetScore()
    {
        return currentTime;
    }
}
