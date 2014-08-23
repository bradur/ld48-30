using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool frozen = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other){
        // removes bullets that leave the area
        if(other.gameObject.tag == "boundary"){
            HitBoundary();
        }
    }

    void HitBoundary(){
        Destroy(gameObject);
    }
}
