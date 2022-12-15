using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rightAngle;
    public float leftAngle;
    bool moveClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeDirection()
    {
        if(transform.rotation.z > rightAngle)
        {
            moveClockwise = false;
        }
        if(transform.rotation.z < leftAngle)
        {
            moveClockwise = true;
        }
    }

    public void Move()
    {
        ChangeDirection();

        if(moveClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }
        if(!moveClockwise)
        {
            rb.angularVelocity = -1 * moveSpeed;
        }
    }
}
