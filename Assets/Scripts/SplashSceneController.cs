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
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("LanguageSelector");
    }
}
