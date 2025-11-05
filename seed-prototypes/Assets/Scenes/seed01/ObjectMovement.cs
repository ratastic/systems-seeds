using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectMovement : MonoBehaviour
{
    public CameraFollow cf;
    public bool canRoll = false;
    public void OnCollisionEnter(Collision col)
    {
        if (canRoll == false) return;

        GameObject other = col.gameObject;

        if (other.TryGetComponent<ObjectMovement>(out ObjectMovement om))
        {
            om.canRoll = true;
            canRoll = false;
            cf.target = other.GetComponent<Transform>();
        }
    }
}
