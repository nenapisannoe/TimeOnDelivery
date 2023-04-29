using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCargo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Store"))
        {
            Transform trans = this.transform;
            Transform childTrans = trans.Find("Bag");
            childTrans.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
