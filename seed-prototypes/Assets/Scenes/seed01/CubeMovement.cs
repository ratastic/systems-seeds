using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeMovement : ObjectMovement
{
    [SerializeField] private float rollSpeed = 3f;
    private bool isMoving;
    //private bool cubeCanRoll;
    //public CylinderMovement cm;
    //public CameraFollow cf;

    void Start()
    {
        canRoll = true;
    }
    void Update()
    {
        //Debug.Log(canRoll);
        if (isMoving) return;

        if (Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        if (Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        if (Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
        if (Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
        
        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * .5f;
            var axis = Vector3.Cross(Vector3.up, dir);

            if (canRoll == true && isMoving == false)
            {
                transform.RotateAround(anchor, axis, rollSpeed * Time.deltaTime);
                //StartCoroutine(Roll(anchor, axis));
            }
        }
    }

    // IEnumerator Roll(Vector3 anchor, Vector3 axis)
    // {
    //     isMoving = true;

    //     // for (int i = 0; i < (90 / rollSpeed); i++)
    //     // {
    //     //     transform.RotateAround(anchor, axis, rollSpeed);
    //     // }

    //     transform.RotateAround(anchor, axis, rollSpeed);
    //     yield return new WaitForSeconds(.01f);

    //     isMoving = false;
    // }
}
