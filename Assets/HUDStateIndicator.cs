using UnityEngine;
using System.Collections;

public class HUDStateIndicator : MonoBehaviour {

    public Color OnColor;
    public Color OffColor;

    public string OffText;
    string onText;

    // state is a variable so that different starting conditions are allowed
    public int currentState = 1;

    TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		onText = textMesh.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetState(int state){
		currentState = state;
		if(currentState == Manager.On){
			textMesh.text = onText;
			textMesh.color = OnColor;
		}
		else if(currentState == Manager.Off){
			textMesh.text = OffText;
			textMesh.color = OffColor;
		}
	}
}
