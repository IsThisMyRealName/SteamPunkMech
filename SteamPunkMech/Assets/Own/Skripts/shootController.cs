using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootController : MonoBehaviour {

    public GameObject shoot;
    public float shootPower;
    public Transform fireLever;
    //public Transform LeverBase;
    public float LeverAngle;
    private bool canFire = true;
    public bool isLaser = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            fireShot();
        }

        LeverAngle = fireLever.eulerAngles.x;
        if((LeverAngle > 355 || LeverAngle < 30) && canFire)
        {
            fireShot();
            if (isLaser)
            {

            }
            else
            {
                canFire = false;
            }
        }
        if (LeverAngle < 325 && LeverAngle > 180)
        {
            canFire = true;
        }
    }

    private void fireShot()
    {
        GameObject g = Instantiate(shoot, shoot.transform.position, shoot.transform.rotation);
        g.SetActive(true);
        g.GetComponent<Rigidbody>().velocity = transform.up * shootPower;
    }
}
