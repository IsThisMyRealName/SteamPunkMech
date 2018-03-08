using System.Collections;
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
            heldObject.GetComponent<GrabbableObject>().move(gameObject); 
            if (controller.triggerButtonUp)
            {
                heldObject.GetComponent<GrabbableObject>().letGo(simulator.velocity);
                heldObject = null;
            }
        }
        else
        {
            if (controller.triggerButtonPressed)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach(Collider col in cols)
                {
                    if (heldObject == null && (col.GetComponent<ThrowableObject>() || col.GetComponent<MoveableObject>()))
                    {
                        heldObject = col.gameObject;
                        heldObject.GetComponent<GrabbableObject>().grab(gameObject);
                        Debug.Log("Object has been grabbed.");
                    }
                }
            }
        }
	}
}
