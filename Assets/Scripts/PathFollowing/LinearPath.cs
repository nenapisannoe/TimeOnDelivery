using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPath : Path
{
    [SerializeField] Transform _start;
    [SerializeField] Transform _end;
    public override Vector3 GetPathPoint(float t)
    {
        var start = _start.position;
        var end = _end.position;
        var difference = end - start;

        return (end - start) * t + start;
    }

    private void OnDrawGizmos()
    {
        var start = _start.position;
        var end = _end.position;
        Gizmos.DrawLine(start, end);
    }
}
