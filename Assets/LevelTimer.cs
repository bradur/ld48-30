using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {

    public float timeLimit = 60.0f;
    public float updateInterval = 1.0f;
    public string appendString = "s";
    float timer;
    float timeLeft;
    TextMesh timeDisplay;

	// Use this for initialization
	void Start () {
        timer = updateInterval;
	    timeDisplay = GetComponent<TextMesh>();
        timeLeft = timeLimit;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
	    if(timer <= 0.0f){
            timeLeft -= updateInterval;
            if(timeLeft <= 0.0f){
                timeLeft = 0.0f;
            }
            UpdateDisplay();
            timer = updateInterval;
        }
	}

    void UpdateDisplay(){
        timeDisplay.text = timeLeft + appendString;
    }

}

