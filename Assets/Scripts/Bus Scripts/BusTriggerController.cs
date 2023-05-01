using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusTriggerController : MonoBehaviour
{
    [SerializeField] BusController _busController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bus stop")
        {
            BusStop busStop = other.gameObject.GetComponentInParent<BusStop>();
            _busController.StopOnBusStop(busStop);
            return;
        }

        if (other.tag == "Player")
        {
            _busController.LoadPassanger(other.gameObject);
        }
    }
}
