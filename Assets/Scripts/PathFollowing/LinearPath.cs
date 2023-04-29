using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPath : Path
{
    [SerializeField] Vector3 _start;
    [SerializeField] Vector3 _end;
    public override Vector3 GetPathPoint(float t)
    {
        var difference = _end - _start;

        return (_end - _start) * t + _start;
    }
}
