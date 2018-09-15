using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour {

    public Button NextBtn;

	// Use this for initialization
	void Start () {
        NextBtn.onClick.AddListener(Next);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Next()
    {
        if(NextBtn.name == "SureButton")
        {
            SceneManager.LoadScene("Slider_Second");
        } else if(NextBtn.name == "Second_Next_Btn")
        {
            SceneManager.LoadScene("Slider_Third");
        }
    }

}
