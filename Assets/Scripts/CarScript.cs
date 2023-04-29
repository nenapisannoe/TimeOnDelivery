using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    void Update()
    {
        // Right just because models are imported the way car's forward is red axis
        Vector3 movement = transform.right * _speed * Time.deltaTime;

        transform.Translate(movement, Space.World);
    }
}
