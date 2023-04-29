using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziePath : Path
{
    [SerializeField] Transform[] _beziePoints;

    public override Vector3 GetPathPoint(float t)
    {
        // For better readability
        var p0 = _beziePoints[0].position;
        var p1 = _beziePoints[1].position;
        var p2 = _beziePoints[2].position;
        var p3 = _beziePoints[3].position;

        // Formula from Wikipedia
        return Mathf.Pow((1 - t), 3)*p0 + 3*t*Mathf.Pow((1-t), 2)*p1 + 3*t*t*(1-t)*p2 + Mathf.Pow(t, 3)*p3;
    }

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            var position = GetPathPoint(t);
            Gizmos.DrawSphere(position, 0.5f);
        }

        Gizmos.DrawSphere(GetPathPoint(1.0f), 0.5f);

        Gizmos.DrawLine(_beziePoints[0].position, _beziePoints[1].position);
        Gizmos.DrawLine(_beziePoints[2].position, _beziePoints[3].position);
    }
}
