using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowingPath : MonoBehaviour
{
    [SerializeField] private Path[] _paths;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _rotationSpeed = 0.15f;
    [SerializeField] private bool _isLooped = false;

    private int _currentPathIndex;

    private float _t;

    private const float EPS = 0.001f;

    void Start()
    {
        _currentPathIndex = 0;
        _t = 0;
    }

    private void Update()
    {
        if (Mathf.Abs(_t - 1.0f) < EPS)
        {
            _currentPathIndex++;
            _t = 0.0f;
        }

        if (_currentPathIndex >= _paths.Length)
        {
            if (!_isLooped) return;

            _currentPathIndex = 0;
        }

        Path path = _paths[_currentPathIndex];

        Vector3 newPosition = path.GetPathPoint(_t);

        Vector3 movement = newPosition - transform.position;
        transform.position = newPosition;

        var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotationSpeed);
        transform.rotation = newRotation;

        _t += Time.deltaTime * _speed;
    }
}
