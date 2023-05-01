using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Boots : MonoBehaviour
{
    [SerializeField] private Image _bootsIcon;

    // For fly animation
    [SerializeField] private GameObject _wheels;
    [SerializeField] private GameObject _turbines;

    [SerializeField] public bool _canJump = false;

    [SerializeField] private float _jump = 14f;
    [SerializeField] private float _jumpSpeed = 4f;
    [SerializeField] private float _jumpHeight = 2f;

    [SerializeField] private Transform _lidarPoint;
    [SerializeField] private float _maximumDistanceToCrossWalk = 5f;

    private PlayerController _playerController;
    private GameObject _particleSystem;

    private Vector3 _directionToRoad = Vector3.zero;

    private const float EPS = 0.2f;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _bootsIcon.gameObject.SetActive(true);
        MakeIconGrey();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!this.enabled || !other.CompareTag("JumpZone"))
        {
            MakeIconGrey();
            return;
        }

        _directionToRoad = other.transform.right;
        _canJump = CanJump();
        if (_canJump)
            MakeIconWhite();
        else
            MakeIconGrey();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!this.enabled || !other.CompareTag("JumpZone")) return;

        MakeIconGrey();
        _canJump = false;
    }

    private bool CanJump()
    {
        if (_directionToRoad.magnitude == 0)
        {
            return false;
        }

        RaycastHit hit;
        if (!Physics.Raycast(_lidarPoint.position, _directionToRoad, out hit))
        {
            return false;
        }

        if (!hit.transform.CompareTag("CrossWalk") && !hit.transform.CompareTag("Fence"))
        {
            Debug.Log(hit.transform.tag);
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
        var tempColor = _bootsIcon.color;
        tempColor.a = 1f;
        _bootsIcon.color = tempColor;
    }

    private void MakeIconGrey()
    {
        var tempColor = _bootsIcon.color;
        tempColor.a = 0.5f;
        _bootsIcon.color = tempColor;
    }

    private void Update()
    {
        if (_canJump && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Jump!");
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        Vector3 destination = transform.position + _directionToRoad * _jump;
        StartCoroutine(JumpCoroutine(destination));
        _canJump = false;
        _bootsIcon.gameObject.SetActive(false);
        this.enabled = false;
    }

    private IEnumerator JumpCoroutine(Vector3 jumpDestination)
    {
        PrepareForFly();
        jumpDestination = jumpDestination + new Vector3(0, _jumpHeight, 0);

        while (Vector3.Distance(transform.position, jumpDestination) > EPS)
        {
            Vector3 movement = _jumpSpeed * Time.deltaTime * _directionToRoad;

            transform.Translate(movement, Space.World);

            yield return null;
        }

        StopFlying();
    }

    private void PrepareForFly()
    {
        _playerController.enabled = false;
        transform.Translate(new Vector3(0, _jumpHeight, 0));
        _wheels.SetActive(false);
        _turbines.SetActive(true);
    }

    private void StopFlying()
    {
        transform.Translate(new Vector3(0, -_jumpHeight, 0));
        _wheels.SetActive(true);
        _turbines.SetActive(false);
        _playerController.enabled = true;
    }
}