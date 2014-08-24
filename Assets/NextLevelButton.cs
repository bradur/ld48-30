using UnityEngine;
using System.Collections;

public class NextLevelButton : MonoBehaviour {
    public Color hoverColor = new Color(1.0f, 1.0f, 1.0f, 0.361f);
    Color originalColor;
    SpriteRenderer sr;
    public string LevelToLoad;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        //Debug.Log(hoverColor);
    }
    
    // Update is called once per frame
    void Update () {

    }

    void OnMouseEnter(){
        sr.color = hoverColor;
    }

    void OnMouseExit(){
        sr.color = originalColor;
    }

    public void LoadNextLevel(){
        Time.timeScale = 1.0f;
        Application.LoadLevel(LevelToLoad);
    }

    void OnMouseUp(){
        LoadNextLevel();
    }
}
