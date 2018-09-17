using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using GoogleARCore.Examples.AugmentedImage;

public class BtnController : MonoBehaviour {
    private string catName;

    private string[] names = { "Oscar", "Max", "Tiger", "Sam", "Misty", "Simba", "Coco", "Chloe", "Lucy", "Sacha", "Puss", "Bella", "Molly", "Milo", "Angel", "Lala", "Ginger", "Smokey" };

    public void Next()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("buttonName" + buttonName);
        switch (buttonName)
        {
            case "Sure_Btn":
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Welcome").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Sure_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("FirstSlider").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("First_Next_Btn").gameObject.SetActive(true);
                break;
            case "First_Next_Btn":
                GameObject.FindGameObjectWithTag("Slider").transform.Find("First_Next_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("FirstSlider").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("SecondSlider").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Second_Next_Btn").gameObject.SetActive(true);
                break;
            case "Second_Next_Btn":
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Second_Next_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("SecondSlider").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("ThirdSlider").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Start_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Random_Btn").gameObject.SetActive(true);
                break;
            case "Start_Btn":
                catName = GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").Find("Text").GetComponent<Text>().text;
                Debug.Log("belefut"+ catName);
                if (catName == "")
                {
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("ThirdSlider").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("Start_Btn").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("Random_Btn").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("WrongSlider").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("Try_Again_Btn").gameObject.SetActive(true);
                } else
                {
                    Debug.Log("else ág");
                    GameObject.FindGameObjectWithTag("Slider").transform.Find("Saving_Txt").gameObject.SetActive(true);
                    PlayerPrefs.SetString("catName", catName);
                    SceneManager.LoadScene("AugmentedImage");
                }
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Slider").transform.Find("WrongSlider").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Try_Again_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("ThirdSlider").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Start_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Random_Btn").gameObject.SetActive(true);
                break;
            case "Show_Map_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().MapOn = true;
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Show_Map_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Map").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Close_Map_Btn").gameObject.SetActive(true);
                break;
            case "Close_Map_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Map").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Close_Map_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().MapOn = false;
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Show_Map_Btn").gameObject.SetActive(true);
                break;
            case "Hej_Speech_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("HejSpeech").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FollowMe").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Let_Start_Btn").gameObject.SetActive(true);
                break;
            default:
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Start_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Slider").transform.Find("Random_Btn").gameObject.SetActive(true);
                break;
        }
       
    }

    public void RandomName()
    {
        System.Random random = new System.Random();
        int nameIndex = random.Next(names.Length);
        string name = names[nameIndex];
        GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").GetComponent<InputField>().text = name;
    }

}
