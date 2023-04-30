using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : CarFollowingPath
{
    private bool _shouldMove = false;

    public bool Stoped { get; private set; } = false;

    public const float CROSSWALK_WIDTH = 4;

    void Update()
    {
        if (!_shouldMove)
        {
            MoveToCrossWalk();
        }
        else
        {
            Move();
        }
    }

    void MoveToCrossWalk()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);

        Vector3 movement = GetMovement();

        Stoped = ShouldStop(hit, movement);
        
        if (!Stoped)
        {
            Move();
        }
    }

    bool ShouldStop(RaycastHit hit, Vector3 movement)
    {
        if (hit.collider == null)
        {
            return false;
        }

        var hitObjectTag = hit.collider.tag;
        
        if (hitObjectTag == "CrossWalk")
        {
            return hit.distance < movement.magnitude + CROSSWALK_WIDTH;
        }

        if (hitObjectTag == "Car")
        {
            CarScript nextCar = hit.collider.gameObject.GetComponent<CarScript>();
            if (nextCar == null)
            {
                return true;
            }

            return nextCar.Stoped && (hit.distance < movement.magnitude);
        }

        return false;
    }

    public void OnGreenLight()
    {
        _shouldMove = true;
    }

    public void OnRedLight()
    {
        _shouldMove = false;
    }
}
