using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossWalkController : MonoBehaviour
{
    [SerializeField] TraficController _traficController;
    [SerializeField] private Collider[] _playerStopers;

    private void Start()
    {
        _traficController.CarRedLight.AddListener(DisableCollider);
        _traficController.CarGreenLight.AddListener(EnableCollider);
    }

    public void EnableCollider()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        foreach (Collider collider in _playerStopers)
        {
            collider.enabled = false;
        }
    }
}
