using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : CarFollowingPath
{
    [SerializeField] private bool _stoped = false;
    [SerializeField] private float _stopSeconds = 3.0f;

    private Collider _collider;
    private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bus stop")
        {
            StartCoroutine(WaitOnBusStop());
            return;
        }

        if (other.tag == "Player")
        {
            _player = other.gameObject;
            _player.SetActive(false);
        }
    }

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _player = null;

        if (_stoped)
        {
            StartCoroutine(WaitOnBusStop());
        }
    }

    private void Update()
    {
        if (!_stoped)
        {
            Move();
        }
    }

    private IEnumerator WaitOnBusStop()
    {
        _stoped = true;
        _collider.isTrigger = true;

        if (_player != null)
        {
            _player.transform.position = transform.position + transform.right * 2;
            _player.SetActive(true);
            _player = null;
        }

        yield return new WaitForSeconds(_stopSeconds);

        _collider.isTrigger = false;
        _stoped = false;
    }
}
