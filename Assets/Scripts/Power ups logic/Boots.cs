using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Boots : MonoBehaviour
{
    [SerializeField] private Image bootsIcon;
    [SerializeField] bool _canJump = false;
    [SerializeField] private float jump = 12f;
    [SerializeField] private float _maximumDistanceToCrossWalk = 5f;

    private void Start()
    {
        bootsIcon.gameObject.SetActive(true);
        MakeIconGrey();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!this.enabled || !other.CompareTag("JumpZone"))
        {
            MakeIconGrey();
            return;
        }
        _canJump = CanJump();
        if (_canJump)
            MakeIconWhite();
        else
            MakeIconGrey();
    }

    private bool CanJump()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            return false;
        }

        if (hit.transform.tag != "CrossWalk")
        {
            return false;
        }

        if (hit.distance > _maximumDistanceToCrossWalk)
        {
            return false;
        }

        return true;
    }

    private void MakeIconWhite()
    {
        var tempColor = bootsIcon.color;
        tempColor.a = 1f;
        bootsIcon.color = tempColor;
    }

    private void MakeIconGrey()
    {
        var tempColor = bootsIcon.color;
        tempColor.a = 0.5f;
        bootsIcon.color = tempColor;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!this.enabled || other.CompareTag("JumpZone")) return;

        MakeIconGrey();
        _canJump = false;
    }

    private void Update()
    {
        if (_canJump && Input.GetKeyDown(KeyCode.E))
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        transform.Translate(transform.forward * jump, Space.World);
        _canJump = false;
        bootsIcon.gameObject.SetActive(false);
        this.enabled = false;
    }
}