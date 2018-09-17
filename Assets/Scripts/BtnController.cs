using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class BtnController : MonoBehaviour {
    private string inputTxt;

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
                inputTxt = GameObject.FindGameObjectWithTag("Slider").transform.Find("Cat_Name_Input").Find("Text").GetComponent<Text>().text;
              
                break;
            default:
                SceneManager.LoadScene("Slider_Third");
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
