using UnityEngine;
using System.Collections;

public class BogeyContainer : MonoBehaviour {

    public GameObject Bogey;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = Bogey.GetComponent<SpriteRenderer>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle () {
        if(sr.enabled){
            sr.enabled = false;
        }
        else{
            sr.enabled = true;
        }
    }

}
