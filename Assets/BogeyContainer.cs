using UnityEngine;
using System.Collections;

public class BogeyContainer : MonoBehaviour {

    public GameObject Bogey;
    SpriteRenderer sr;

    BoxCollider2D bColl;
    CircleCollider2D cColl;
    PolygonCollider2D pColl;

	// Use this for initialization
	void Start () {
        sr = Bogey.GetComponent<SpriteRenderer>();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle () {
        if(sr != null){
            if(sr.enabled){
                sr.enabled = false;
            }
            else{
                sr.enabled = true;
            }
        }
    }

    public void DisableColliders(){
        foreach(Transform child in transform){
            bColl = child.gameObject.GetComponent<BoxCollider2D>();
            cColl = child.gameObject.GetComponent<CircleCollider2D>();
            pColl = child.gameObject.GetComponent<PolygonCollider2D>();
            if(bColl != null){
                bColl.enabled = false;
            }
            if(cColl != null){
                cColl.enabled = false;
            }
            if(pColl != null){
                pColl.enabled = false;
            }
        }
    }

}
