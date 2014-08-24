using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public GameObject AllBogeys;
    BogeyManager bogeyManager;

    public GameObject AllAmmo;
    AmmoPowerupManager ammoManager;

    public GameObject Player;
    Player player;

    public GameObject HUDObject;
    HUD hud;

/*
    public GameObject Music;*/
    MusicManager musicManager;

    int worldState = Manager.RealWorld;

    public Color Color1;
    public Color Color2;

    public float switchInterval = 5.0f;
    public float switchBackInterval = 2.0f;

    public float dreamWorldSlowDown = 0.5f;

    public float keyPressCoolDown = 0.2f;
    float keyPressTimer;

    public bool SwitchIsReady = true;
    float timer = 0.0f;
    float backTimer = 0.0f;

    SpriteRenderer[] spriteArray;

    SpriteRenderer levelSprite;
    

	// Use this for initialization
	void Start () {
        keyPressTimer = keyPressCoolDown;
        hud = HUDObject.GetComponent<HUD>();
	    levelSprite = gameObject.GetComponent<SpriteRenderer>();
        bogeyManager = AllBogeys.GetComponent<BogeyManager>();
        ammoManager = AllAmmo.GetComponent<AmmoPowerupManager>();
        player = Player.GetComponent<Player>();
        backTimer = switchBackInterval;

        musicManager = GameObject.FindGameObjectsWithTag("MusicManager")[0].GetComponent<MusicManager>();

        int i = 0;
        spriteArray = new SpriteRenderer[transform.childCount+1];
        spriteArray[i++] = levelSprite;
        foreach(Transform child in transform){
            spriteArray[i++] = child.gameObject.GetComponent<SpriteRenderer>();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

    void SetColor(Color newColor){

        for(int i = 0;i < spriteArray.Length; i++){
            spriteArray[i].color = newColor;
        }
    }

    void Switch() {
        timer = switchInterval;
        // when we come into CleanWorld
        if(worldState == Manager.RealWorld){
            musicManager.ChangePitchTo(0.5f);
            Time.timeScale = 0.5f;
            worldState = Manager.DreamWorld;
            SetColor(Color2);
            ammoManager.SetWorldState(worldState);
            player.SetWorldState(worldState);
        }
        // when we come out of CleanWorld
        else if(worldState == Manager.DreamWorld){
            if(Time.timeScale == dreamWorldSlowDown){
                Time.timeScale = 1.0f;
            }
            musicManager.ResetPitch();
            SetSwitchNotReady(); // set switch not ready
            backTimer = switchBackInterval;
            worldState = Manager.RealWorld;
            SetColor(Color1);
            ammoManager.SetWorldState(worldState);
            player.SetWorldState(worldState);
        }
        //Debug.Log("Switch: " + (worldState == 1 ? "RealWorld" : "DreamWorld") + " -> " + (worldState == 2 ? "RealWorld" : "DreamWorld") );
        bogeyManager.Toggle();
        // "return" key is broken :D
    }

    public void RestartLevel(){
        if(player != null){
            player.DieANonNaturalDeath();
        }
    }

}
