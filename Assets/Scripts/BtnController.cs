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

    public string backpackFrom;

    public void Next()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
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
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Show_Map_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Map").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Close_Map_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().MapOn = true;
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
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Cat_Txt").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Txt").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FollowMe").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Let_Start_Btn").gameObject.SetActive(true);
                break;
            case "Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstAfter").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstBackpack").gameObject.SetActive(true);
                break;
            case "Continue_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstAfter").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").transform.GetComponent<Animator>().Play("catAnim_14");
                StartCoroutine(OpenTheSecondQuiz());
                break;
            case "Close_Backpack_Btn":
                if(backpackFrom == "SecondQuizImage")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(true);
                    backpackFrom = "";
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstAfter").gameObject.SetActive(true);
                }
                break;
            case "Second_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondAfter").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(true);
                break;
            case "Second_Continue_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondAfter").gameObject.SetActive(false);
                // TODO: Induljon el a következő animáció ( a harmadik quiz előtti )
                // Bemutatóig:
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBefore").gameObject.SetActive(true);
                break;
            case "Close_Second_Backpack_Btn":
                if (backpackFrom == "ThirdQuizImage")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").gameObject.SetActive(true);
                    backpackFrom = "";
                }
                else if(backpackFrom == "ThirdBeforeImage")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBefore").gameObject.SetActive(true);
                    backpackFrom = "";
                } else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondAfter").gameObject.SetActive(true);
                }
                break;
            case "Third_Before_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<BtnController>().backpackFrom = "ThirdBeforeImage";
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBefore").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(true);
                break;
            case "Third_Before_Continue_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBefore").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").gameObject.SetActive(true);
                break;
            case "Third_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdAfter").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBackpack").gameObject.SetActive(true);
                break;
            case "Third_Continue_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdAfter").gameObject.SetActive(false);
                // TODO: Induljon el a következő animáció ( a negyedik quiz előtti )
                break;
            case "Close_Third_Backpack_Btn":
                if (backpackFrom == "FourthQuizImage")
                {
                    // TODO   
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdAfter").gameObject.SetActive(true);
                }
                break;
            default:
                Debug.Log("Something went wrong");
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

    IEnumerator OpenTheSecondQuiz()
    {
        yield return new WaitForSeconds(18);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").gameObject.SetActive(true);
    }
}
