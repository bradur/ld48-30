using UnityEngine;
using System.Collections;

public class AmmoCount : MonoBehaviour {

    public int ammoCount;

    public GameObject HUDObject;
    HUD hud;

    bool initialAmmoCheck = false;

    TextMesh ammoDisplayText;

	// Use this for initialization
	void Start () {
        ammoDisplayText = GetComponent<TextMesh>();
        hud = HUDObject.GetComponent<HUD>();

	}
	
	// Update is called once per frame
	void Update () {
        if(!initialAmmoCheck){
    	    if(ammoCount == 0){
                hud.SetState(Manager.Out, Manager.IndicatorLaser);
            }
            ammoDisplayText.text = ammoCount + "";
            initialAmmoCheck = false;
        }
	}



    public bool NotOut(){
        if(ammoCount > 0) {
            return true;
        }
        return false;
    }

    public void RemoveAmmo(){
        ammoCount--;
        UpdateTextDisplay();
    }

    public void AddAmmo(){
        ammoCount++;
        UpdateTextDisplay();
    }

    public void UpdateTextDisplay(){
        ammoDisplayText.text = ammoCount + "";
        hud.SetState(Manager.Off, Manager.IndicatorLaser);
    }

}
