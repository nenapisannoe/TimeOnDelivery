using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    
    public void SpawnPlayer(GameObject player)
    {
        player.transform.position = _playerSpawnPoint.position;
        player.SetActive(true);
    }
}
