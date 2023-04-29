using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

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
            RegularMove();
        }
    }

    void MoveToCrossWalk()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.right, out hit);

        Vector3 movement = transform.right * _speed * Time.deltaTime;

        Stoped = ShouldStop(hit, movement);
        
        if (!Stoped)
        {
            transform.Translate(movement, Space.World);
        }
    }

    bool ShouldStop(RaycastHit hit, Vector3 movement)
    {
        if (hit.collider == null)
        {
            return true;
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

    void RegularMove()
    {
        Stoped = false;
        
        // Right just because models are imported the way car's forward is red axis
        Vector3 movement = transform.right * _speed * Time.deltaTime;

        transform.Translate(movement, Space.World);
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
