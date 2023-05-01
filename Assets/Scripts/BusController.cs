using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController: CarFollowingPath
{
    [SerializeField] private float _stopSeconds = 3.0f;

    private bool _stoped = false;

    [SerializeField] private Collider _collider;
    private GameObject _player;
    
    public void StopOnBusStop(BusStop busStop)
    {
        StartCoroutine(WaitOnBusStop(busStop));
    }

    public void LoadPassanger(GameObject passanger)
    {
        _player = passanger;
        _player.SetActive(false);
    }

    private void Start()
    {
        _player = null;
    }

    private void Update()
    {
        if (!_stoped)
        {
            Move();
        }
    }

    private IEnumerator WaitOnBusStop(BusStop busStop)
    {
        _stoped = true;
        _collider.isTrigger = true;

        if (_player != null)
        {
            busStop.SpawnPlayer(_player);
            _player = null;
        }

        yield return new WaitForSeconds(_stopSeconds);

        _collider.isTrigger = false;
        _stoped = false;
    }
}
