using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool menuActive = false;
    private bool controlsActive = false;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _controls;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuActive)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            _pauseMenu.SetActive(!menuActive);
            _controls.SetActive(false);
            menuActive = !menuActive;
        }
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Controls()
    {
        _controls.SetActive(!controlsActive);
        controlsActive = !controlsActive;
    }
}
