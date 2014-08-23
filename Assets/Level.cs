using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public GameObject AllBogeys;
    BogeyManager bogeyManager;
    public GameObject Player;
    Player player;
    

    int worldState = Manager.RealWorld;

    public Color Color1;
    public Color Color2;

    public float switchInterval = 5.0f;
    public float switchBackInterval = 2.0f;


    bool switched = false;
    float timer = 0.0f;
    float backTimer = 0.0f;

    SpriteRenderer levelSprite;
    

	// Use this for initialization
	void Start () {

	    levelSprite = gameObject.GetComponent<SpriteRenderer>();
        bogeyManager = AllBogeys.GetComponent<BogeyManager>();
        player = Player.GetComponent<Player>();
        backTimer = switchBackInterval;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
    	    if(Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)){

                Switch();
                switched = true;
            }
        }
        if(switched){
            backTimer -= Time.deltaTime;
            if(backTimer < 0.0f){
                Switch();
                switched = false;
                backTimer = switchBackInterval;
            }
        }
	}

    void Switch() {
        timer = switchInterval;
        if(worldState == Manager.RealWorld){
            worldState = Manager.DreamWorld;
            levelSprite.color = Color2;
            player.SetWorldState(worldState);
        }
        else{
            worldState = Manager.RealWorld;
            levelSprite.color = Color1;
            player.SetWorldState(worldState);
        }
        bogeyManager.Toggle();
        // "return" key is broken :D
    }

}
