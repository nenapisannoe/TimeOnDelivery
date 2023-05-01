using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private PlayerController _controller;

    private void Start()
    {
        _controller = GetComponent<PlayerController>();
        _controller.ShouldSlowDownOnPuddle = false;
    }
}
