using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLightController : MonoBehaviour {

    public bool isDamaged = false;
    public Light damageLight;
    public Transform cockpit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getHit()
    {
        if (isDamaged)
        {
            Debug.Log(transform.name + " is destroyed!");
            return true;
        }
        else
        {
            isDamaged = true;
            StartCoroutine(BlinkDamageLight());
            return false;
        }
    }

    public void repair()
    {
        isDamaged = false;
        cockpit.GetComponent<HealthController>().repair(transform.GetComponent<Collider>());
    }

    IEnumerator BlinkDamageLight()
    {
        damageLight.intensity = 7;
        yield return new WaitForSeconds(.5f);
        damageLight.intensity = 0;
        yield return new WaitForSeconds(.5f);
        if (isDamaged)
        {
            StartCoroutine(BlinkDamageLight());
        }
    }
}
