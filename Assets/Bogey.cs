using UnityEngine;
using System.Collections;

public class Bogey : MonoBehaviour {
    float moveTimer;
    public float MaxMoveInterval;

    public GameObject MyPerimeter;

    public float MaxForce;

    Vector2 currentMovement;

    public bool goBack = false;
    float step;

    float vertical;
    float horizontal;
    float x_angle;

	// Use this for initialization
	void Start () {
        moveTimer = Random.Range(0.0f, MaxMoveInterval);
	}
	
	// Update is called once per frame
	void Update () {
	    moveTimer -= Time.deltaTime;
        if(moveTimer < 0.0f && !goBack){
            MoveRandomly();
            moveTimer = Random.Range(0.0f, MaxMoveInterval);
            //Debug.Log(moveTimer);
        }
        else if(goBack){
            step = MaxForce/3.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MyPerimeter.transform.position, step);
            if(transform.position == MyPerimeter.transform.position){
                goBack = false;
            }
        }
	}

    void MoveRandomly() {
        x_angle = Random.Range(-MaxForce, MaxForce);
        horizontal = Random.Range(-MaxForce, MaxForce);
        vertical = Random.Range(-MaxForce, MaxForce);

        transform.Rotate(0.0f, 0.0f, x_angle);
        currentMovement = new Vector2(horizontal, vertical);

        rigidbody2D.AddForce(currentMovement);
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name == MyPerimeter.name){
            //Debug.Log("Leaving perimeter!");
            //rigidbody2D.AddForce(-currentMovement);
            goBack = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == MyPerimeter.name){
            //Debug.Log("Entering perimeter!");
            //rigidbody2D.AddForce(-currentMovement);
            moveTimer = Random.Range(0.0f, MaxMoveInterval);
        }
    }
}
