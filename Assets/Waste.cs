using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waste : MonoBehaviour {

    public List<Color> colorList = new List<Color>();

    public float colorChangeStep = 0.1f;
    public float colorChangeInterval = 0.1f;
   // public float colorChangeDuration = 0.5f;

    //float lerpControl;
    SpriteRenderer sr;
    float timer;

    int currentColorIndex = 0;

	// Use this for initialization
	void Start () {
	   sr = GetComponent<SpriteRenderer>();
       timer = colorChangeInterval;
       //timer = colorChangeInterval;
	}

	// Update is called once per frame
	void Update () {
        //Debug.Log(Time.deltaTime);
        if(timer <= Time.deltaTime){
            sr.color = colorList[currentColorIndex];
            if(currentColorIndex+1 == colorList.Count){
                currentColorIndex = 0;
            }
            else{
                currentColorIndex++;
            }
            timer = colorChangeInterval;
            //Debug.Log("colorChange | timer: " + timer);
        }
        else{
            //Debug.Log("colorLerp");
            sr.color = Color.Lerp(sr.color, colorList[currentColorIndex], Time.deltaTime / timer);
            //Debug.Log("colorLerp | timer: " + timer);
            timer -= Time.deltaTime;
        }
        //Debug.Log(Time.deltaTime);
        /*timer -= Time.deltaTime;
	    if(timer < 0.0f){*/
            /*
            sr.color = Color.Lerp(sr.color, colorList[currentColorInList], lerpControl);
            //Debug.Log(sr.color + " - " + colorList[currentColorInList]);

            if(lerpControl < 1){
                //Debug.Log("lerpControl");
                lerpControl += colorChangeStep;
            }

            //timer = colorChangeInterval;

            // change color to lerp to
            if(sr.color == colorList[currentColorInList]){
                //Debug.Log("equals");
                currentColorInList++;
                if(currentColorInList >= colorList.Count){
                    currentColorInList = 0;
                    lerpControl = 0;
                }
            }
            */
        //}
	}


}
