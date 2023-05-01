using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial3Scenario : MonoBehaviour
{
    [SerializeField] private DeliveryManager _player;
    [SerializeField] private Text TutorialText;
    [SerializeField] private bool step2done;
    [SerializeField] private bool step3done;
    [SerializeField] private bool step4done;
    void Start()
    {
        _player = FindObjectOfType<DeliveryManager>();
        TutorialText.text = "New delivery task! First, pick up the package!";
        
    }

    private void FixedUpdate()
    {
        if (!step2done && _player.cargoPicked)
        {
            StepTwo();
            step2done = true;
        }

        if (step2done && _player.gameObject.GetComponent<PlayerController>().slowed)
        {
            StepThree();
            step3done = true;
        }

        if (step3done && _player.deliveredInTutorial)
        {
            StepFour();
            step4done = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (step4done)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void StepFour()
    {
        TutorialText.text = "Excellent! The package has been delivered! Time for your next task. Press space when you are ready.";
    }

    private void StepTwo()
    {
        TutorialText.text = "Now, all of our corporations' bots are programmed to abide the traffic laws. Wait for the green light, cross the road, and deliver the package!";
    }
    private void StepThree()
    {
        TutorialText.text =
            "Sometimes objects on the road may slow you down. Next time, try and find a way to avoid them.";
    }
}
