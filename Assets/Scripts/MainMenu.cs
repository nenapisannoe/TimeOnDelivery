using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject levelContainer;
    [SerializeField] Transform target;
    [SerializeField] float speedMove;
 
    // Use this for initialization
    public void TurnOn () {
        menuContainer.SetActive(true);
        levelContainer.SetActive(false);
    }

    public void TurnOff () {
        menuContainer.SetActive(false);
        levelContainer.SetActive(true);
    }

        
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial 1");
    }

    public void PlayFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PlaySecondLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
    
    public void Creators()
    {
        SceneManager.LoadScene("Authors");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        if (GameConfig.instance.currentLevel == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(GameConfig.instance.currentLevel + 1);
        }
        
    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(GameConfig.instance.currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
