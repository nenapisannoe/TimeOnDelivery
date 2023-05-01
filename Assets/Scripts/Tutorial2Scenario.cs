using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial2Scenario : MonoBehaviour
{
    [SerializeField] private DeliveryManager _player;
    [SerializeField] private Text TutorialText;
    [SerializeField] private bool step2done;
    [SerializeField] private bool step3done;
    void Start()
    {
        _player = FindObjectOfType<DeliveryManager>();
        TutorialText.text = "Look! Our noble corporation left something for you to improve your work performance! Why dont you go and pick it up.";
        
    }

    private void FixedUpdate()
    {
        if (!step2done && _player.gameObject.GetComponent<Boots>().enabled)
        {
            StepTwo();
            step2done = true;
        }
        
    }

    private void StepTwo()
    {
        TutorialText.text = "Now, in the right corner of your screen, you can see the indicator. It will light up when you can use the power-up.";
    }
}
