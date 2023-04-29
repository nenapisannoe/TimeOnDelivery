using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _rotationSpeed = 0.15f;

    private Vector2 _move;

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
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

        transform.Translate(movement * _speed * Time.deltaTime, Space.World);
    }
}