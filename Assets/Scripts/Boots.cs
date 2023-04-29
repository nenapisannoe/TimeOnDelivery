using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boots : MonoBehaviour
{
    [SerializeField] private Image bootsIcon;
    [SerializeField] bool canJump = false;

    private void Start()
    {
        bootsIcon.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled)
        {
            if (other.CompareTag("JumpZone"))
            {
                var tempColor = bootsIcon.color;
                tempColor.a = 1f;
                bootsIcon.color = tempColor;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    Debug.Log(hit.transform.tag);
                    if (hit.transform.tag == "CrossWalk")
                    {
                        canJump = true;
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = Vector3.right * 10f;
            canJump = false;
            bootsIcon.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.enabled)
        {
            if (other.CompareTag("JumpZone"))
            {
                var tempColor = bootsIcon.color;
                tempColor.a = 0.5f;
                bootsIcon.color = tempColor;
            }
            canJump = false;
        }
    }
}