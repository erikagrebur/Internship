using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour {

    public Button NextBtn;
    public Button SkipBtn;

	// Use this for initialization
	void Start () {
        NextBtn.onClick.AddListener(Next);
        SkipBtn.onClick.AddListener(Skip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Next()
    {
        if(NextBtn.name == "First_Next_Btn")
        {
            SceneManager.LoadScene("Slider_Second");
        } else if(NextBtn.name == "Second_Next_Btn")
        {
            SceneManager.LoadScene("Slider_Third");
        }
    }

    private void Skip()
    {
        SceneManager.LoadScene("AugmentedImage");
    }
}
