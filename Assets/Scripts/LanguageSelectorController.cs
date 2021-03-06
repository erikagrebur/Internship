﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageSelectorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void LanguageSelector()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "EnglishButton":
                PlayerPrefs.SetString("appLang", "English");
                break;
            case "DanishButton":
                PlayerPrefs.SetString("appLang", "Danish");
                break;
            case "GermanButton":
                PlayerPrefs.SetString("appLang", "German");
                break;
            default:
                PlayerPrefs.SetString("appLang", "Danish");
                break;
        }
        SceneManager.LoadScene("AugmentedImage");
    }
}
