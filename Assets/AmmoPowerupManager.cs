using UnityEngine;
using System.Collections;

public class AmmoPowerupManager : MonoBehaviour {

    int worldState = Manager.RealWorld;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetWorldState(int state){
        worldState = state;
        bool enable = false;
        if(worldState == Manager.RealWorld){
            enable = false;
        }
        else if(worldState == Manager.DreamWorld){
            enable = true;
        }
        foreach(Transform child in transform){
            child.gameObject.GetComponent<CircleCollider2D>().enabled = enable;
            child.gameObject.GetComponent<SpriteRenderer>().enabled = enable;
        }
    }
}
