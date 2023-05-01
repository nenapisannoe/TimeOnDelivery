using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial2Scenario : MonoBehaviour
{
    [SerializeField] private DeliveryManager _player;
    [SerializeField] private Boots _boots;
    [SerializeField] private Ghost _ghost;
    [SerializeField] private Text TutorialText;
    [SerializeField] private GameObject powerup; 
    [SerializeField] private bool step2done;
    [SerializeField] private bool step3done;
    [SerializeField] private bool step4done;
    [SerializeField] private bool step5done;
    [SerializeField] private bool step6done;
    void Start()
    {
        _player = FindObjectOfType<DeliveryManager>();
        _boots = FindObjectOfType<Boots>(true);
        _ghost = FindObjectOfType<Ghost>(true);
        TutorialText.text = "New delivery task! First, pick up the package!";
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (step6done)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
        if (!step2done && _player.cargoPicked )
        {
            powerup.SetActive(true);
            StepTwo();
            step2done = true;
        }

        if (step2done && _boots.enabled)
        {
            StepThree();
            step3done = true;
        }

        if (step3done && _boots._canJump)
        {
            StepFour();
            step4done = true;
        }

        if (step4done && _ghost.enabled)
        {
            StepFive();
            step5done = true;
        }
        if (step5done && _player.deliveredInTutorial)
        {
            TutorialText.text = "Excellent! The package has been delivered! Time for your next task. If you want to start the level again, press 'R', and if you are ready to get to work, press Space. Good luck! ";
            step6done = true;
        }
    }

    private void StepThree()
    {
        TutorialText.text = "Now, in the right corner of your screen, you can see the indicator. It will light up when you can use the power-up.";
    }

    private void StepFour()
    {
        TutorialText.text = "Now, this power-up can help you jump over the traffic. Press 'E' in front of the road you want to jump ver to use it!";
    }

    private void StepTwo()
    {
        TutorialText.text = "Look! Our noble corporation left something for you to improve your work performance! Why dont you go and pick it up."; 
    }

    private void StepFive()
    {
        TutorialText.text = "Look, another power up! This one can help you with those obstacles that slow you down. With these on, you dont have to worry about them.";
    }
}
