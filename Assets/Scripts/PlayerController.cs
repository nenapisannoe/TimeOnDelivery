using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _rotationSpeed = 0.15f;

    [SerializeField] private float slowering = 2.0f;
    public bool slowed = false;

    [SerializeField] private float _gravity = -9.8f;
    
    private CharacterController _characterController;

    private Vector2 _move;
    

    public bool ShouldSlowDownOnPuddle { get; set; } = true;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (gameObject.activeInHierarchy && isActiveAndEnabled)
        {
            _move = context.ReadValue<Vector2>();
        } else
        {
            _move = Vector2.zero;
        }
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0.0f, _move.y);

        if (movement.magnitude < 0.01)
            return;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotationSpeed);

        movement.y = _gravity;

        _characterController.Move(movement * Speed() * Time.deltaTime);
        // transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }

    private float Speed()
    {
        if (slowed && ShouldSlowDownOnPuddle)
        {
            return _speed / slowering;
        }

        return _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (collision.collider == null)
            return;

        var colissionGameObjectTag = collision.collider.tag;

        if (colissionGameObjectTag == "Car")
        {
            Debug.Log("End of the game");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Line" && ShouldSlowDownOnPuddle)
        {
            slowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Line")
        {
            slowed = false;
        }
    }
}

