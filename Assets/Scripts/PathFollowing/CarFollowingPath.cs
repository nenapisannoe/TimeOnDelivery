using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowingPath : MonoBehaviour
{
    [SerializeField] private Path[] _paths;

    [SerializeField] protected float _speed = 0.5f;
    [SerializeField] protected float _rotationSpeed = 0.15f;
    [SerializeField] private bool _isLooped = false;

    private int _currentPathIndex;

    private float _t;

    private const float EPS = 0.001f;

    public void SetPaths(Path[] paths, bool isLooped)
    {
        if (paths == null || paths.Length == 0)
        {
            Debug.LogError("Paths should not be empty or null");
            return;
        }

        _currentPathIndex = 0;
        _t = 0;

        _paths = paths;
        _isLooped = isLooped;
    }

    public float Speed {
        get { return _speed; }
        set 
        { 
            if (value > 0.0f)
                _speed = value;
        }
    }

    // Not pure

    protected Vector3 NextPosition()
    {
        if (Mathf.Abs(_t - 1.0f) < EPS)
        {
            _currentPathIndex++;
            _t = 0.0f;
        }

        if (_currentPathIndex >= _paths.Length)
        {
            if (!_isLooped) return transform.position;

            _currentPathIndex = 0;
        }

        Path path = _paths[_currentPathIndex];

        Vector3 newPosition = path.GetPathPoint(_t);

        return newPosition;
    }

    protected Vector3 GetMovement()
    {
        return NextPosition() - transform.position;
    }

    // Pure
    protected Quaternion NextRotation(Vector3 nextPosition)
    {
        Vector3 movement = nextPosition - transform.position;

        if (movement.magnitude < EPS)
        {
            return Quaternion.identity;
        }

        return Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), _rotationSpeed);
    }

    protected void Move()
    {
        var newPosition = NextPosition();
        var newRotation = NextRotation(newPosition);

        // Has to be later than NextRotation because it uses previous position refering transform.position
        transform.position = newPosition;
        transform.rotation = newRotation;

        _t += Time.deltaTime * _speed;
    }

    private void Start()
    {
        _currentPathIndex = 0;
        _t = 0;
    }

    private void Update()
    {
        Move();
    }
}
