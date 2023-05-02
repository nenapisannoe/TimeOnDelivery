using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial1Scenario : MonoBehaviour
{
    [SerializeField] private DeliveryManager _player;
    [SerializeField] private Text TutorialText;
    [SerializeField] private bool step2done;
    [SerializeField] private bool step3done;
    void Start()
    {
        _player = FindObjectOfType<DeliveryManager>();
        TutorialText.text = "Delivery bot G1G4-DLVR, welcome to your first day at work. To begin the delivery, pick up the package from the store in the red building.";
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (step2done && step3done)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
        if (!step2done && _player.cargoPicked)
        {
            StepTwo();
            step2done = true;
        }

        if (!step3done && _player.deliveredInTutorial)
        {
            StepThree();
            step3done = true;
        }
        
    }

    private void StepTwo()
    {
        TutorialText.text = "Good! Now, deliver the package to the blue building (specifically to the door).";
    }
    private void StepThree()
    {
        TutorialText.text = "Excellent! The package has been delivered! Time for your next task. Press space when you are ready.";
    }
}
