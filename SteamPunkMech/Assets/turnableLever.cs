using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class turnableLever : MonoBehaviour, GrabbableObject
{
    public Transform cockpit;
    private Vector3 targetForward;
    private Vector3 targetUp;
    public Transform Wrapper;
    public Transform leverBase;
    public float upAngle;

    void Start()
    {
        upAngle = transform.localEulerAngles.x;
    }
    public void grab(GameObject controller)
    {
        Debug.Log(transform.name + " has been grabbed");
        move(controller);
    }

    public void letGo(Vector3 velocity)
    {

    }

    public void move(GameObject controller)
    {
        targetForward = leverBase.InverseTransformPoint(controller.transform.position);
        targetForward = new Vector3(0, targetForward.y, targetForward.z);
        targetUp = Quaternion.AngleAxis(90, leverBase.right) * targetForward;
        //targetForward = leverBase.TransformPoint(targetForward);
        //targetUp = leverBase.TransformPoint(targetUp);
        float forwardAngle = Vector3.SignedAngle(leverBase.forward, targetForward, leverBase.right);
        upAngle = Vector3.SignedAngle(leverBase.up, targetUp, leverBase.right);
        transform.parent.transform.localEulerAngles = new Vector3(upAngle-180, 0, 0);
        //Wrapper.transform.LookAt(targetForward, targetUp);
        //Wrapper.transform.right = cockpit.right;
    }

}
