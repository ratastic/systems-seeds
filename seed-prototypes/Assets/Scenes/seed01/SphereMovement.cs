using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereMovement : ObjectMovement
{
    public float speed = 5f;
    private Rigidbody rb;
    //public bool ballRolling;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canRoll = false;
    }

    void Update()
    {
        if (canRoll == true)
        {
            BallRoll();
        }
    }

    // Update is called once per frame
    public void BallRoll()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * speed);
        }
    }
}
