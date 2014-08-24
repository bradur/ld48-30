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


    public float HitBogeyResizeMultiplier = 0.75f;
    public bool DoubleHitKill = true;
    public bool move = true;

    public float DoubleHitKillInterval = 0.2f;
    public float SingleHitsToKill = 4;
    int hitsSustained = 0;
    float latestHit;


	// Use this for initialization
	void Start () {
        moveTimer = Random.Range(0.0f, MaxMoveInterval);
	}
	
	// Update is called once per frame
	void Update () {
        if(move){
    	    moveTimer -= Time.deltaTime;
            if(moveTimer < 0.0f && !goBack){
                MoveRandomly();
                moveTimer = Random.Range(0.0f, MaxMoveInterval);
            }
            else if(goBack){
                step = MaxForce/3.0f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, MyPerimeter.transform.position, step);
                if(transform.position == MyPerimeter.transform.position){
                    goBack = false;
                }
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
            goBack = true;
        }
    }

    void DieANonNaturalDeath(){
        Destroy(gameObject);
    }

    void GetHit(){
        hitsSustained++;
        //float test = Time.time-latestHit;
        //Debug.Log("timepassed: "+ test + " interval: " + DoubleHitKillInterval);
        if(Time.time-latestHit <= DoubleHitKillInterval || SingleHitsToKill <= hitsSustained){
            DieANonNaturalDeath();
        }
        else{
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            transform.localScale = new Vector3(x*HitBogeyResizeMultiplier, y*HitBogeyResizeMultiplier, 1.0f);
        }
        latestHit = Time.time;
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == MyPerimeter.name){
            moveTimer = Random.Range(0.0f, MaxMoveInterval);
        }
        if(other.gameObject.tag == "bullet"){
            Destroy(other.gameObject);
            GetHit();
        }
    }
}
