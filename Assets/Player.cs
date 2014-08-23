using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject BulletPosition;

    public float ShootInterval = 1.0f;
    float shootTimer = 0.0f;
    public float RotateSpeed = 1.0f;

    GameObject bullet;

    public GameObject AllBullets;
    BulletManager bulletManager;
    

    int worldState = Manager.RealWorld;

	// Use this for initialization
	void Start () {
        bulletManager = AllBullets.GetComponent<BulletManager>();
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer -= Time.deltaTime;
	    if(shootTimer < 0.0f){
            if(worldState == Manager.DreamWorld){
                if(Input.GetKey(KeyCode.Space)){
                    Shoot();
                    shootTimer = ShootInterval;
                }
            }
        }
        if(Input.GetKey("left")){
            transform.Rotate(0.0f, 0.0f, RotateSpeed);
        }
        if(Input.GetKey("right")){
            transform.Rotate(0.0f, 0.0f, -RotateSpeed);
        }
        if(Input.GetKey("up")){
            transform.Translate(Vector3.up * Time.deltaTime);
        }
	}

    void Shoot(){
        bullet = (GameObject)Instantiate(Resources.Load("Prefabs/bullet"), BulletPosition.transform.position, transform.rotation);
        bullet.transform.parent = AllBullets.transform;
    }

    // if the player hits the bogey
    void OnTriggerEnter2D(Collider2D coll){
        if(worldState == Manager.RealWorld){
            if(coll.gameObject.tag == "bogey"){
                Destroy(gameObject);
            }
        }
    }

    // if the bogey spawns on top of the player after a world switch
    void OnTriggerStay2D(Collider2D coll){
        if(worldState == Manager.RealWorld){
            if(coll.gameObject.tag == "bogey"){
                Destroy(gameObject);
            }
        }
    }

    public void SetWorldState(int state){
        worldState = state;
        bulletManager.SetWorldState(state);
    }
}
