﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WandController))]
public class GrabController : MonoBehaviour {

    private GameObject heldObject;
    private WandController controller;

    Rigidbody simulator;
	// Use this for initialization
	void Start () {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;
        controller = GetComponent<WandController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;
            if (controller.gripButtonUp)
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
            }
        }
        else
        {
            if (controller.gripButtonPressed)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach(Collider col in cols)
                {
                    if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = col.gameObject;
                        heldObject.GetComponent<GrabbableObject>().grab(gameObject);
                    }
                }
            }
        }
	}
}
