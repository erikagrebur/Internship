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

        Debug.Log("eeeeeeehvhjfjhfhjfhj");
        StandUp();
    }

    public void StandUp()
    {
        Debug.Log("itt vagyok, ez a FrameLower: " + GameObject.FindGameObjectWithTag("Cat"));
        GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("idle_02_copy_sit_before_stand_up");
    }
}
