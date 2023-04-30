using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private GameObject bag;
    [SerializeField] public bool cargoPicked;

    private void Start()
    {
        cargoPicked = false;
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
                GameOver();
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("You win");
    }
    
}
