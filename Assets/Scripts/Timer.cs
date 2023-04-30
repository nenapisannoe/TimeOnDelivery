using System.Collections;
using System.Collections.Generic;
using Unity.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLeft = 30.0f;
    [SerializeField] private Text timerText;
    private bool timeOver = false;

    void Start()
    {
        timeOver = false;
    }
    void Update()
    {
        if (!timeOver)
        {
            timeLeft -= Time.deltaTime;
            DisplayTime(timeLeft);
            if (timeLeft <= 0)
            {
                timeOver = true;
                GameOver();
            }
        }
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
