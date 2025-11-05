using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ObjectMovement : MonoBehaviour
{
    public CameraFollow cf;
    public bool canRoll = false;
    static bool updated = false; 
    public void OnCollisionEnter(Collision col)
    {
        if (canRoll == false || updated == true) return;

        GameObject other = col.gameObject;

        if (other.TryGetComponent<ObjectMovement>(out ObjectMovement om))
        {
            Debug.Log($"collided with {other.name}");
            om.canRoll = true;
            canRoll = false;
            cf.target = other.GetComponent<Transform>();

            updated = true;
        }
        //Debug.Log($"{other.name}");
    }

    void LateUpdate()
    {
        updated = false;
    }
}
