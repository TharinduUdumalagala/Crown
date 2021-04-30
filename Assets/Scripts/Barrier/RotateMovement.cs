using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : Barrier
{
    [SerializeField]
    private float rotateSpeed;
    private Vector3 _currentTarget;

    public override void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
