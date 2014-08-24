using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

    public GameObject HelpMenu;
    OverlayMenu helpMenu;
    bool menuOn = false;

    public Color hoverColor = new Color(1.0f, 1.0f, 1.0f, 0.361f);
    Color originalColor;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
	    helpMenu = HelpMenu.GetComponent<OverlayMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp(){
        ToggleHelp();
    }

    void OnMouseEnter(){
        sr.color = hoverColor;
    }

    void OnMouseExit(){
        sr.color = originalColor;
    }

    void ToggleHelp(){
        if(menuOn){
            menuOn = false;
            helpMenu.GoBack();
        }
        else if(!menuOn){
            menuOn = true;
            helpMenu.BringOn();
        }
        
    }
}
