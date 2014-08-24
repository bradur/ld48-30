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
        if(other.gameObject.tag == "wall"){
            HitWall();
        }

        if(other.gameObject.tag == "bogey"){
            HitBogey();
        }

    }

    void HitBoundary(){
        Destroy(gameObject);
    }

    void HitWall(){
        Destroy(gameObject);
    }

    void HitBogey(){
        //Destroy(gameObject);
    }

}
