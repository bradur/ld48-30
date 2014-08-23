using UnityEngine;
using System.Collections;

public class BogeyManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle () {
        foreach(Transform child in transform) {
            child.GetComponent<BogeyContainer>().Toggle();
        }
    }
}
