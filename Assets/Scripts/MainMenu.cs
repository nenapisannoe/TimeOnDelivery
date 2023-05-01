using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(GameConfig.instance.currentLevel + 1);
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
