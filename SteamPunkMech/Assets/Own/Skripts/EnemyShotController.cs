using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {

    public Transform shootingPosition;
    public Transform[] Targets = new Transform[6];
    public Transform Cockpit;
    private int Target;
    public float timeBetweenAttacks;
    public float laserWidthStart;
    public float laserWidthEnd;
    private LineRenderer laser;
    public float LaserTime;
    public bool isAttacking = false;

    // Use this for initialization
    void Start () {
        laser = shootingPosition.GetComponent<LineRenderer>();
        StartCoroutine(AttackCycle(timeBetweenAttacks));
    }


    public void startAttacking()
    {
        isAttacking = true;
    }
	IEnumerator AttackCycle(float attackTime)
    {
        yield return new WaitForSeconds(attackTime);
        if (isAttacking)
        {
            
            Target = Random.Range(0, Targets.Length);
            StartCoroutine(shoot(Targets[Target]));
        }
        else
        {
            StartCoroutine(AttackCycle(attackTime));
        }
    }

    IEnumerator shoot(Transform shotTarget)
    { 
        laser.SetPosition(1, shotTarget.position);
        laser.widthMultiplier = laserWidthStart;
        while(laser.widthMultiplier < laserWidthEnd)
        {
            laser.SetPosition(0, shootingPosition.position);
            laser.widthMultiplier = laser.widthMultiplier + Time.deltaTime * laserWidthEnd / LaserTime;
            yield return new WaitForEndOfFrame();
        }
        RaycastHit hit;
        Physics.Raycast(shootingPosition.position, shotTarget.position - shootingPosition.position, out hit);
        Debug.Log(hit.collider.transform.name);
        Cockpit.GetComponent<HealthController>().hit(hit.collider);
        laser.widthMultiplier = 0;
        StartCoroutine(AttackCycle(timeBetweenAttacks));
    }
}
