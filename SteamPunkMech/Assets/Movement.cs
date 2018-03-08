using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform rightLever;
    public Transform leftLever;
    private float rightLeverLastAngle;
    private float leftLeverLastAngle;

    public float pushPower;
    private float rightPushPower;
    private float leftPushPower;

    void Start()
    {
        rightLeverLastAngle = rightLever.localEulerAngles.x;
        leftLeverLastAngle = leftLever.localEulerAngles.x;
    }
	
	// Update is called once per frame
	void Update ()
	{

	    rightPushPower = -(rightLeverLastAngle - rightLever.localEulerAngles.x);
        Debug.Log(rightLever.localEulerAngles);
	    if (rightPushPower > .5f)
	    {
	        GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower * rightPushPower), transform.TransformPoint(new Vector3(50, 0, 0)));

        }
        rightLeverLastAngle = rightLever.localEulerAngles.x;

	    leftPushPower = -(leftLeverLastAngle - leftLever.localEulerAngles.x);
	    if (leftPushPower > .5f)
	    {
	        GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower * leftPushPower), transform.TransformPoint(new Vector3(-50, 0, 0)));
        }
	    leftLeverLastAngle = leftLever.localEulerAngles.x;
    }
}
