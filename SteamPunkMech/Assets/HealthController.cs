using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public Collider[] Parts = new Collider[6];


    public void hit(Collider col)
    {
        foreach (Collider bodyPart in Parts)
        {
            if(bodyPart == col)
            {
                Debug.Log(bodyPart.transform.name + " was hit");
            }
        }
    }
}
