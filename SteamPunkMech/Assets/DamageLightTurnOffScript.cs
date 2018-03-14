using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLightTurnOffScript : MonoBehaviour, GrabbableObject
{
    public DamageLightController LightController;
    public void grab(GameObject controller)
    {
        LightController.repair();
    }

    public void letGo(Vector3 velocity)
    {
        
    }

    public void move(GameObject controller)
    {
        
    }
}
