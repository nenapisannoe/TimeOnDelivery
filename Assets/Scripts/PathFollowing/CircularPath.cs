using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPath : Path
{
    [SerializeField] float _radius;

    public override Vector3 GetPathPoint(float t)
    {
        var center = transform.position;
        t = t * 2 * Mathf.PI;
        var x = _radius * Mathf.Cos(t) + center.x;
        var y = center.y;
        var z = _radius * Mathf.Sin(t) + center.z;
        return new Vector3(x, y, z);
    }

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            var position = GetPathPoint(t);
            Gizmos.DrawSphere(position, 0.5f);
        }

        Gizmos.DrawSphere(GetPathPoint(1.0f), 0.5f);
    }
}
