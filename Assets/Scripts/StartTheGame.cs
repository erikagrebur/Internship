using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("HejSpeech").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("LetStartButton").gameObject.SetActive(false);
    }
}
