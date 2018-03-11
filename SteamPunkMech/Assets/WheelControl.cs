using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WheelControl : MonoBehaviour, GrabbableObject {

    public Transform cannon;
    public Transform wheelHandle;
    private Vector3 wheelToController;
    private Vector3 target;
    private Quaternion targetAngle;
    private Quaternion lastFrameRotation;
    private float turnedAnglesDirection;
    private float turnedAngles;
    private float lastFrameAngles;
    private float cannonRotation;
    public float turnFactor;

    public void grab(GameObject controller)
    {
        wheelToController = controller.transform.position - transform.position;
        target = Vector3.ProjectOnPlane(wheelToController, transform.forward);
        targetAngle = Quaternion.LookRotation(transform.forward, target);
        transform.rotation = targetAngle;
    }

    public void letGo(Vector3 velocity)
    {
        
    }

    public void move(GameObject controller)
    {
        wheelToController = controller.transform.position - transform.position;
        target = Vector3.ProjectOnPlane(wheelToController, transform.forward);
        targetAngle = Quaternion.LookRotation(transform.forward, target);
        transform.rotation = targetAngle;
    }
    void Start()
    {
        turnedAnglesDirection = 0;
        turnedAnglesDirection = 0;
        lastFrameAngles = transform.rotation.z;
        lastFrameRotation = transform.rotation;
        targetAngle = transform.rotation;
        cannonRotation = cannon.rotation.x;
    }
    void FixedUpdate()
    {
        turnedAnglesDirection = Vector3.SignedAngle(lastFrameRotation.eulerAngles, targetAngle.eulerAngles, transform.forward);
        if(turnedAnglesDirection > 0)
        {
            turnedAngles += Quaternion.Angle(lastFrameRotation, targetAngle);
            Debug.Log(turnedAngles);
        }
        if(turnedAnglesDirection < 0)
        {
            turnedAngles -= Quaternion.Angle(lastFrameRotation, targetAngle);
            Debug.Log(turnedAngles);
        }
        //cannon.rotation = cannon.rotation + new Vector3(turnedAngles * turnFactor, 0, 0);
        cannon.Rotate(cannon.right, turnedAngles * turnFactor);
        lastFrameRotation = targetAngle;
        turnedAngles = 0;
    }

}
