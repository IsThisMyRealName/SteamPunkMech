using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

	public Collider[] Parts = new Collider[6];
    public bool[] partIsDamaged = new bool[6];


    public void hit(Collider col)
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            if (col.Equals(Parts[i]))
            {
                Debug.Log(Parts[i].transform.name + " was hit");
                partIsDamaged[i] = true;
                Parts[i].transform.GetComponent<DamageLightController>().getHit();
            }
        }
    }

    public void repair(Collider col)
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            if (col.Equals(Parts[i]))
            {
                Debug.Log(Parts[i].transform.name + " was repaired");
                partIsDamaged[i] = false;
            }
        }
    }
}
