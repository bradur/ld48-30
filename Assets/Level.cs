using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public GameObject AllBogeys;
    BogeyManager bogeyManager;

    public GameObject Player;
    Player player;

    public GameObject HUDObject;
    HUD hud;

    int worldState = Manager.RealWorld;

    public Color Color1;
    public Color Color2;

    public float switchInterval = 5.0f;
    public float switchBackInterval = 2.0f;

    public float keyPressCoolDown = 0.2f;
    float keyPressTimer;

    public bool SwitchIsReady = true;
    float timer = 0.0f;
    float backTimer = 0.0f;

    SpriteRenderer levelSprite;

	// Use this for initialization
	void Start () {
        keyPressTimer = keyPressCoolDown;
        hud = HUDObject.GetComponent<HUD>();
	    levelSprite = gameObject.GetComponent<SpriteRenderer>();
        bogeyManager = AllBogeys.GetComponent<BogeyManager>();
        player = Player.GetComponent<Player>();
        backTimer = switchBackInterval;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        keyPressTimer -= Time.deltaTime;
        if(timer <= 0.0f && !SwitchIsReady){
            SetSwitchReady();
        }
        if(keyPressTimer <= 0.0f){
    	    if(SwitchIsReady &&
              (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
            ){
                Switch();
                keyPressTimer = keyPressCoolDown;
            }
        }
        if(worldState == Manager.DreamWorld){
            backTimer -= Time.deltaTime;
            if(backTimer < 0.0f){
                Switch();
                SetSwitchNotReady();
                backTimer = switchBackInterval;
            }
        }
	}

    void SetSwitchReady(){
        SwitchIsReady = true;
        hud.SetState(Manager.On, Manager.IndicatorSwitch);
    }

    void SetSwitchNotReady(){
        SwitchIsReady = false;
        hud.SetState(Manager.Off, Manager.IndicatorSwitch);
    }

    void Switch() {
        timer = switchInterval;
        // when we come into CleanWorld
        if(worldState == Manager.RealWorld){
            worldState = Manager.DreamWorld;
            levelSprite.color = Color2;
            player.SetWorldState(worldState);
        }
        // when we come out of CleanWorld
        else if(worldState == Manager.DreamWorld){
            SetSwitchNotReady(); // set switch not ready
            backTimer = switchBackInterval;
            worldState = Manager.RealWorld;
            levelSprite.color = Color1;
            player.SetWorldState(worldState);
        }
        Debug.Log("Switch: " + (worldState == 1 ? "RealWorld" : "DreamWorld") + " -> " + (worldState == 2 ? "RealWorld" : "DreamWorld") );
        bogeyManager.Toggle();
        // "return" key is broken :D
    }

}
