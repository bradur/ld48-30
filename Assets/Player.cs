using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float ShootInterval = 1.0f;
    float shootTimer = 0.0f;
    public float RotateSpeed = 1.0f;

    GameObject bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer -= Time.deltaTime;
	    if(shootTimer < 0.0f){
            if(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)){
                Shoot();
                shootTimer = ShootInterval;
            }
        }
        if(Input.GetKey("left")){
            transform.Rotate(0.0f, 0.0f, RotateSpeed);
        }
        if(Input.GetKey("right")){
            transform.Rotate(0.0f, 0.0f, -RotateSpeed);
        }
        if(Input.GetKey("up")){
            Debug.Log("up");
            transform.Translate(Vector3.up * Time.deltaTime);
        }
	}

    void Shoot(){
        bullet = (GameObject)Instantiate(Resources.Load("Prefabs/bullet"), transform.position, transform.rotation);
        bullet.rigidbody2D.AddRelativeForce(new Vector2(0.0f, 40.0f));
    }
}
