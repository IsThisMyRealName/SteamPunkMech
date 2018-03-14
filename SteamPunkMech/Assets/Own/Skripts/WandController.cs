using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    public bool menuButtonDown = false;

    public EnemyShotController enemy;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        menuButtonDown = controller.GetPressDown(menuButton);

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);
        if (menuButtonDown)
        {
            Debug.Log("MenuButton pressed");
            enemy.startAttacking();
            
        }
        if (gripButtonDown)
        {
            Debug.Log("Grip Button was just pressed");
        }

        if (gripButtonUp)
        {
            Debug.Log("Grip Button was just let go");
        }

        if (triggerButtonDown)
        {
            Debug.Log("trigger Button was just pressed");
        }

        if (triggerButtonUp)
        {
            Debug.Log("trigger Button was just let go");
        }
    }
}
