using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform rightLever;
    public Transform leftLever;
    public Transform rightDirectionLever;
    public Transform leftDirectionLever;
    private float rightLeverLastAngle;
    private float leftLeverLastAngle;

    public float pushPower;
    private float rightPushPower;
    private float leftPushPower;

    public int leftDirection = 1;
    public int rightDirection = 1;

    void Start()
    {
        rightLeverLastAngle = rightLever.localEulerAngles.x;
        leftLeverLastAngle = leftLever.localEulerAngles.x;
    }
	
	// Update is called once per frame
	void Update ()
	{
        float leftAngle = Mathf.Abs(leftDirectionLever.GetComponentInChildren<turnableLever>().upAngle);
        float rightAngle = Mathf.Abs(rightDirectionLever.GetComponentInChildren<turnableLever>().upAngle);
        rightPushPower = -(rightLeverLastAngle - rightLever.localEulerAngles.x);
        if(leftDirection == -1 && leftAngle <= 25)
        {
            leftDirection = 1;
            Debug.Log("Left walking Forwards");
        }
        if(leftDirection == 1 && leftAngle >= 155)
        {
            leftDirection = -1;
            Debug.Log("Left walking Backwards");
        }
        if (rightDirection == -1 && rightAngle <= 25)
        {
            rightDirection = 1;
        }
        if (rightDirection == 1 && rightAngle >= 155)
        {
            rightDirection = -1;
        }
        if (rightPushPower > .5f)
	    {
	        GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower * rightPushPower * rightDirection), transform.TransformPoint(new Vector3(50, 0, 0)));

        }
        rightLeverLastAngle = rightLever.localEulerAngles.x;

	    leftPushPower = -(leftLeverLastAngle - leftLever.localEulerAngles.x);
	    if (leftPushPower > .5f)
	    {
	        GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower * leftPushPower * leftDirection), transform.TransformPoint(new Vector3(-50, 0, 0)));
        }
	    leftLeverLastAngle = leftLever.localEulerAngles.x;
    }
}
