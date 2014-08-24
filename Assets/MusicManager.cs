using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    AudioSource song;
    float originalPitch;

    float destinationPitch;

    void Awake () {
        DontDestroyOnLoad(gameObject);
    }

    	// Use this for initialization
	void Start () {
        if(GameObject.FindGameObjectsWithTag("MusicManager").Length > 1){
            // reset pitch after
            GameObject.FindGameObjectsWithTag("MusicManager")[0].GetComponent<MusicManager>().ResetPitch();
            Destroy(gameObject);
        }
        else{
            song = GetComponent<AudioSource>();
            originalPitch = song.pitch;
            song.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangePitchTo(float newPitch){
        song.pitch = newPitch;
    }

    public void ResetPitch(){
        song.pitch = originalPitch;
    }
}
