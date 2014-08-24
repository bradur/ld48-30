using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

    int worldState = Manager.RealWorld;
    public float BulletForce = 40.0f;

    Bullet bullet;
    BoxCollider2D coll;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // see if we're back in the real world
        if(worldState == Manager.RealWorld){
            // look through all the bullets...
            foreach(Transform child in transform){
                bullet = child.gameObject.GetComponent<Bullet>();
                coll = child.gameObject.GetComponent<BoxCollider2D>();

                // if a bullet is frozen (as they are in DreamWorld)
                if (bullet.frozen){
                    coll.enabled = true;
                    // release it
                    bullet.rigidbody2D.AddRelativeForce(new Vector2(0.0f, BulletForce));
                    bullet.frozen = false;
                }
            }
        }
	}

    public void SetWorldState(int state){
        worldState = state;
    }

}
