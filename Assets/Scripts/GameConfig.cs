using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameConfig : MonoBehaviour
{
    [Serializable]
    public class Rating
    {
        public int oneStar;
        public int twoStars;
        public int threeStars;
        
        public Rating(int _one, int _two, int _three)
        {
            oneStar = _one;
            twoStars = _two;
            threeStars = _three;
        }
    }
    
    
    public static GameConfig instance { get; private set; }
    public List<float> statistics = new List<float>();
    public List<Rating> results = new List<Rating>();
    public int currentLevel = 0;
    private void Awake()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 6; i++)
        {
            statistics.Add(0);
        }
        {
            
        }
        if (instance != null && instance != this) 
        { 
            Destroy(this.gameObject); 
        } 
        else 
        { 
            instance = this; 
        } 
        DontDestroyOnLoad(this);
    }

    public void AddScore(float score, int level)
    {
        statistics[level - 4] = score;
        currentLevel = level;
    }

    public Rating GetCurrentStat()
    {
        return results[currentLevel-4];
    }
    
    public float GetCurrentRes()
    {
        return statistics[currentLevel-4];
    }
}
