using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private GameObject bag;
    [SerializeField] public bool cargoPicked;
    [SerializeField] public bool deliveredInTutorial;
    private Timer _timer;
    private float _score;

    private void Start()
    {
        cargoPicked = false;
        _timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Store"))
        {
            bag.GetComponent<Renderer>().material.color = Color.red;
            cargoPicked = true;
            return;
        }

        if (other.CompareTag("Finish"))
        {
            if (cargoPicked)
            {
                _timer.StopTimer();
                OnLevelEnded();
            }
        }
        
        if (other.CompareTag("TutorialFinish"))
        {
            if (cargoPicked)
            {
                deliveredInTutorial = true;
            }
        }
    }

    public void GetScore(float d)
    {
        _score = d;
    }
    public void OnLevelEnded()
    {
        GameConfig.instance.AddScore(_timer.GetScore(), SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("You win");
    }
    
}
