using UnityEngine;
using System.Collections;

public class OverlayMenu : MonoBehaviour {

    public GameObject Destination;
    public float speed = 10.0f;

    Vector3 currentDestination;
    Vector3 originalPosition;

    public GameObject AllBogeys;
    BogeyManager bogeyManager;

    public bool changePitch = true;
    public float newPitch = 2.5f;

    public bool changeTime = true;

    MusicManager musicManager;

    bool movingTo = false;
    //bool movingBack;

    // Use this for initialization
    void Start () {
        if(AllBogeys != null){
            bogeyManager = AllBogeys.GetComponent<BogeyManager>();
        }
        originalPosition = transform.position;
        // singleton hack
        musicManager = GameObject.FindGameObjectsWithTag("MusicManager")[0].GetComponent<MusicManager>();
    }
    
    // Update is called once per frame
    void Update () {
       if(movingTo){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, step);
            if(transform.position == currentDestination){
                movingTo = false;
                if(changeTime){
                    Time.timeScale = 0;
                }
                if(changePitch){
                    musicManager.ChangePitchTo(newPitch);
                }
            }
       }
    }

    public void BringOn(){
        movingTo = true;
        currentDestination = Destination.transform.position;
        if(bogeyManager != null){
            bogeyManager.DisableAllColliders();
        }
    }

    public void GoBack(){
        movingTo = true;
        currentDestination = originalPosition;
        if(bogeyManager != null){
            bogeyManager.DisableAllColliders();
        }
    }

}
