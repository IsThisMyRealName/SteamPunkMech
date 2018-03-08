using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveableObject : MonoBehaviour, GrabbableObject{
    public void grab(GameObject controller)
    {
        transform.parent.transform.LookAt(controller.transform.position);
    }

    public void letGo(Vector3 velocity)
    {
        
    }

    public void move(GameObject controller)
    {
        transform.parent.transform.LookAt(controller.transform.position);
    }
}
