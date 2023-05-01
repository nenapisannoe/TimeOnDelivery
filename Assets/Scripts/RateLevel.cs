using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateLevel : MonoBehaviour
{
    [SerializeField] private GameObject starsLayout;
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;
    void Start()
    {
        var stat = GameConfig.instance.GetCurrentStat();
        var res = GameConfig.instance.GetCurrentRes();
        if (res > stat.oneStar)
        {
            DrawTransparentStar(star2);
            DrawTransparentStar(star3);
            DrawFullStar(star1);
        }
        else if (res <= stat.twoStars && res >= stat.threeStars)
        {
            DrawFullStar(star1);
            DrawFullStar(star2);
            DrawTransparentStar(star3);
        }
        else if (res <= stat.threeStars)
        {
            DrawFullStar(star1);
            DrawFullStar(star2);
            DrawFullStar(star3);
        }
    }

    private void DrawFullStar(GameObject star)
    {
        star.SetActive(true);
    }
    private void DrawTransparentStar(GameObject star)
    {
        var tempColor = star.GetComponent<Image>().color;
        tempColor.a = 0.1f;
        star.GetComponent<Image>().color = tempColor;
        star.SetActive(true);
    }
}
