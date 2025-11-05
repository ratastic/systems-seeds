using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3f;
    private bool isMoving;
    private bool cubeCanRoll;
    public CylinderMovement cm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeCanRoll = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;

        if (Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        if (Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        if (Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
        if (Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
        
        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * .5f;
            var axis = Vector3.Cross(Vector3.up, dir);

            if (cubeCanRoll == true)
            {
                StartCoroutine(Roll(anchor, axis));
            }
        }
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(.01f);
        }

        isMoving = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("cylinder"))
        {
            Debug.Log("collided with cylinder");
            cubeCanRoll = false;
            cm.cylinderCanRoll = true;
        }
    }
}
