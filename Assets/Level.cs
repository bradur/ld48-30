using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public GameObject AllBogeys;
    BogeyManager bg;

    public Color Color1;
    public Color Color2;

    public float switchTimer = 5.0f;
    float timer = 0.0f;

    SpriteRenderer sr;
    

	// Use this for initialization
	void Start () {
	   sr = gameObject.GetComponent<SpriteRenderer>();
       bg = AllBogeys.GetComponent<BogeyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
    	    if(Input.GetKey(KeyCode.Space)){
                Switch();
            }
        }
	}

    void Switch() {
        timer = switchTimer;
        if(sr.color == Color1){
            sr.color = Color2;
        }
        else{
            sr.color = Color1;
        }
        bg.Toggle();
        // "return" key is broken :D
    }

}
