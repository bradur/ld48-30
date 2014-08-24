using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

    public bool visible = false;

    BoxCollider2D bColl;
    CircleCollider2D cColl;
    PolygonCollider2D pColl;
    SpriteRenderer sr;
    TextMesh text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle(){
        ToggleChildren(gameObject);
    }

    void ToggleChildren(GameObject parent){
        foreach(Transform child in parent.transform){
            bColl = child.GetComponent<BoxCollider2D>();
            cColl = child.GetComponent<CircleCollider2D>();
            pColl = child.GetComponent<PolygonCollider2D>();
            sr = child.GetComponent<SpriteRenderer>();
            text = child.GetComponent<TextMesh>();

            if(bColl != null){
                bColl.enabled = bColl.enabled ? false : true;
            }
            if(cColl != null){
                cColl.enabled = cColl.enabled ? false : true;
            }
            if(pColl != null){
                pColl.enabled = pColl.enabled ? false : true;
            }
            if(text != null){
                text.renderer.enabled = text.renderer.enabled ? false : true;
            }
            if(child.childCount > 0){
                ToggleChildren(child.gameObject);
            }
        }

    }

}
