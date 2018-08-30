using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(OpenScene());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("LanguageSelector");
    }
}
