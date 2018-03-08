using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowableObject : MonoBehaviour, GrabbableObject {
    public void grab(GameObject controller)
    {
        transform.parent = controller.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void move()
    {
        throw new NotImplementedException();
    }

    public void letGo()
    {
        throw new NotImplementedException();
    }

}
