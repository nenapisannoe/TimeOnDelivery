using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _rotationSpeed = 0.15f;
    [SerializeField] private CharacterController _characterController;
<<<<<<< HEAD
    [SerializeField] private float slowering = 2.0f;
    private bool slowed = false;
=======
>>>>>>> parent of 0ced3f3 (added line & working on boots)

    private Vector2 _move;

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0.0f, _move.y);

        if (movement.magnitude < 0.01)
            return;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotationSpeed);

        _characterController.Move(movement * _speed * Time.deltaTime);
        // transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null)
            return;

        var colissionGameObjectTag = collision.collider.tag;

        if (colissionGameObjectTag == "Car")
        {
            Debug.Log("End of the game");
        }
    }
<<<<<<< HEAD

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Line")
        {
            if (!slowed)
            {
                _speed = _speed / slowering;
                slowed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Line")
        {
            _speed = 8.0f;
            slowed = false;
        }
    }
=======
>>>>>>> parent of 0ced3f3 (added line & working on boots)
}
