using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CylinderMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed, rotationTilt;
    public bool cylinderCanRoll;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();

        cylinderCanRoll = false;
        if (cylinderCanRoll == true)
        {
            FixedUpdate();
        }
    }

    public void FixedUpdate()
    {
        float upDown = Input.GetAxis("Vertical");
        float leftRight = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, 0, upDown * moveSpeed);
        Vector3 tilt = new Vector3(0, 0, leftRight * rotationTilt);

        rb.AddForce(movement);

        Quaternion playerRotationVar = Quaternion.Euler(-tilt * Time.deltaTime);

        rb.MoveRotation(rb.rotation * playerRotationVar);
    }
}
