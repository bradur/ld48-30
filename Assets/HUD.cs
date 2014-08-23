using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public GameObject CurrentWorld;
    public GameObject WorldSwitch;
    public GameObject Laser;

    HUDStateIndicator currentWorldIndicator;
    HUDStateIndicator worldSwitchIndicator;
    HUDStateIndicator laserIndicator;

    HUDStateIndicator[] hudStates;

	// Use this for initialization
	void Start () {
	    currentWorldIndicator = CurrentWorld.GetComponent<HUDStateIndicator>();
        worldSwitchIndicator = WorldSwitch.GetComponent<HUDStateIndicator>();
        laserIndicator = Laser.GetComponent<HUDStateIndicator>();

        hudStates = new HUDStateIndicator[]{
            currentWorldIndicator,
            worldSwitchIndicator,
            laserIndicator
        };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetState(int state, int type){
        hudStates[type].SetState(state);
    }
}
