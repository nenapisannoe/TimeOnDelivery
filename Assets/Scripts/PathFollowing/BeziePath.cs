using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziePath : Path
{
    [SerializeField] Transform[] _beziePoints;

    private Vector3 _p0;
    private Vector3 _p1;
    private Vector3 _p2;
    private Vector3 _p3;

    private void Start()
    {
        _p0 = _beziePoints[0].position + transform.position;
        _p1 = _beziePoints[1].position + transform.position;
        _p2 = _beziePoints[2].position + transform.position;
        _p3 = _beziePoints[3].position + transform.position;
    }

    public override Vector3 GetPathPoint(float t)
    {
        // Formula from Wikipedia
        return Mathf.Pow((1 - t), 3)*_p0 + 3*t*Mathf.Pow((1-t), 2)*_p1 + 3*t*t*(1-t)*_p2 + Mathf.Pow(t, 3)*_p3;
    }

    private void OnDrawGizmos()
    {
        _p0 = _beziePoints[0].position + transform.position;
        _p1 = _beziePoints[1].position + transform.position;
        _p2 = _beziePoints[2].position + transform.position;
        _p3 = _beziePoints[3].position + transform.position;
        for (float t = 0; t <= 1; t += 0.05f)
        {
            var position = GetPathPoint(t);
            Gizmos.DrawSphere(position, 0.5f);
        }

        Gizmos.DrawSphere(GetPathPoint(1.0f), 0.5f);

        Gizmos.DrawLine(_p0, _p1);
        Gizmos.DrawLine(_p2, _p3);
    }
}
