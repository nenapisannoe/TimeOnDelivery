using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private string buff = "Boots";
    
    public void PickUpBuff()
    {
        var co = player.GetComponent(buff);
        Behaviour be = co as Behaviour;
        if (be != null)
        {
            be.enabled = true;
        }
    }

    public void UseBuff()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpBuff();
            Destroy(gameObject);
        }
    }
}
