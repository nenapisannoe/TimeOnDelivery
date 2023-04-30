using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : CarFollowingPath
{
    [SerializeField] private float _carWidth = 1.25f;

    public float CarWidth { get { return _carWidth; } }

    public bool Stoped { get; private set; } = false;

    public const float CROSSWALK_WIDTH = 4;

    void Update()
    {
        MoveToCrossWalk();
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
            TraficController traficController = hit.collider.gameObject.GetComponent<TraficController>();

            if (traficController == null)
                return false;

            return !traficController.CarGreen && hit.distance < movement.magnitude + CROSSWALK_WIDTH;
        }

        if (hitObjectTag == "Car")
        {
            CarScript nextCar = hit.collider.gameObject.GetComponent<CarScript>();
            if (nextCar == null)
            {
                return true;
            }

            return nextCar.Stoped && (hit.distance < movement.magnitude + nextCar.CarWidth);
        }

        return false;
    }
}
