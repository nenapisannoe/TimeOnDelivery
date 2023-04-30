using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpCargo : MonoBehaviour
{
    [SerializeField] private GameObject bag;
    [SerializeField] public bool cargoPicked;

    void Start()
    {
        cargoPicked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Store"))
        {
            bag.GetComponent<Renderer>().material.color = Color.red;
            cargoPicked = true;
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
