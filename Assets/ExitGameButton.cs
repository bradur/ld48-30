using UnityEngine;
using System.Collections;

public class ExitGameButton : MonoBehaviour {
    public Color hoverColor = new Color(1.0f, 1.0f, 1.0f, 0.361f);
    Color originalColor;
    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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

    void OnMouseUp(){
        Application.Quit();
    }
}
