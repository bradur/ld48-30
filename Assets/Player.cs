using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject SFXHurt;
    AudioSource sfxHurt;
    public GameObject SFXLaser;
    AudioSource sfxLaser;
    public GameObject SFXReload;
    AudioSource sfxReload;

    public GameObject SFXPowerup;
    AudioSource sfxPowerup;

    public GameObject BulletPosition;

    public GameObject AmmoCount;
    AmmoCount ammoCount;

    public GameObject GameOver;
    OverlayMenu gameOverMenu;

    public GameObject NextLevel;
    OverlayMenu nextLevelMenu;

    public GameObject HUDObject;
    HUD hud;

    public float ShootInterval = 1.0f;
    float shootTimer;
    public float RotateSpeed = 1.0f;

    GameObject bullet;

    public GameObject AllBullets;
    BulletManager bulletManager;

    bool laserIsReady = false;

    int worldState = Manager.RealWorld;

	// Use this for initialization
	void Start () {
        ammoCount = AmmoCount.GetComponent<AmmoCount>();
        bulletManager = AllBullets.GetComponent<BulletManager>();
        hud = HUDObject.GetComponent<HUD>();
        shootTimer = ShootInterval;
        sfxHurt = SFXHurt.GetComponent<AudioSource>();
        sfxLaser = SFXLaser.GetComponent<AudioSource>();
        sfxReload = SFXReload.GetComponent<AudioSource>();
        sfxPowerup = SFXPowerup.GetComponent<AudioSource>();
        gameOverMenu = GameOver.GetComponent<OverlayMenu>();
        nextLevelMenu = NextLevel.GetComponent<OverlayMenu>();
	}
	
	// Update is called once per frame
	void Update () {
        if(ammoCount.NotOut()){
            shootTimer -= Time.deltaTime;
        }
	    if(shootTimer < 0.0f && !laserIsReady){
            SetLaserReady();
        }
        if(laserIsReady){
            SetLaserReady();
            if(worldState == Manager.DreamWorld){
                if(Input.GetKey(KeyCode.Space)){
                    Shoot();
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
        if(Input.GetKey("down")){
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
        }
	}

    void Shoot(){
        if(ammoCount.NotOut()){
            bullet = (GameObject)Instantiate(Resources.Load("Prefabs/bullet"), BulletPosition.transform.position, transform.rotation);
            bullet.transform.parent = AllBullets.transform;
            SetLaserNotReady();
            sfxLaser.Play();
            ammoCount.RemoveAmmo();
        }
    }

    
    void OnTriggerEnter2D(Collider2D coll){
        if(worldState == Manager.RealWorld){
            // if the player hits the bogey
            if(coll.gameObject.tag == "bogey"){
                DieANonNaturalDeath();
            }
        }
        if(coll.gameObject.tag == "ammo"){
            Destroy(coll.gameObject);
            sfxPowerup.Play();
            ammoCount.AddAmmo();
        }
        if(coll.gameObject.tag == "exitdoor"){
            nextLevelMenu.BringOn();
        }
    }

    // if the bogey spawns on top of the player after a world switch
    void OnTriggerStay2D(Collider2D coll){
        if(worldState == Manager.RealWorld){
            if(coll.gameObject.tag == "bogey"){
                DieANonNaturalDeath();
            }
        }
    }

    public void DieANonNaturalDeath(){
        sfxHurt.Play();
        Destroy(gameObject);
        gameOverMenu.BringOn();
    }

    void SetLaserNotReady(){
        if(ammoCount.NotOut()){
            laserIsReady = false;
            hud.SetState(Manager.Off, Manager.IndicatorLaser);
            shootTimer = ShootInterval;
        }
        else{
            hud.SetState(Manager.Out, Manager.IndicatorLaser);
        }
    }

    void SetLaserReady(){
        if(ammoCount.NotOut()){
            if(!laserIsReady){
                sfxReload.Play();
            }
            laserIsReady = true;
            hud.SetState(Manager.On, Manager.IndicatorLaser);
        }
        else{
            hud.SetState(Manager.Out, Manager.IndicatorLaser);
        }
    }

    public void SetWorldState(int state){
        worldState = state;
        bulletManager.SetWorldState(state);
        hud.SetState(state, Manager.IndicatorCurrent);
    }
}
