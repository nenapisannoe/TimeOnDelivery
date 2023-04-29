using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boots : MonoBehaviour
{
    [SerializeField] private Image bootsIcon;

    private void Start()
    {
        bootsIcon.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled)
        {
            //Debug.Log(other.name);
            //Debug.Log(gameObject.name);
            if (other.CompareTag("JumpZone"))
            {
                Debug.Log("collidedJump");
                var tempColor = bootsIcon.color;
                tempColor.a = 1f;
                bootsIcon.color = tempColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var tempColor = bootsIcon.color;
        tempColor.a = 0.5f;
        bootsIcon.color = tempColor;
    }
}