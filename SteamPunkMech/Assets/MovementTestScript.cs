using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTestScript : MonoBehaviour {

    // Update is called once per frame
    public float pushPower = 25;
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            Debug.Log("Right button pressed");
            GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower), transform.TransformPoint(new Vector3(75, 0, 0)));
        }
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Left button pressed");
            //GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1) * pushPower), transform.TransformPoint(gameObject.transform.position + new Vector3(-100, 0, 0)));
            GetComponent<Rigidbody>().AddForceAtPosition(transform.TransformDirection(new Vector3(0, 0, 1)) * pushPower, transform.TransformPoint(new Vector3(-75, 0, 0)));

        }
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, transform.rotation.y, 0, transform.rotation.w), 30f * Time.deltaTime);

    }
}
