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
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("WelcomeElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").gameObject.SetActive(true);
                break;
            case "First_Next_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").gameObject.SetActive(true);
                break;
            case "Second_Next_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(true);
                break;
            case "Start_Btn":
                catName = GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").Find("Text").GetComponent<Text>().text;
                if (catName == "")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").gameObject.SetActive(true);
                } else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Saving_Txt").gameObject.SetActive(true);
                    PlayerPrefs.SetString("catName", catName);
                    GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().ShouldFollow = true;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(false);
                }
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(true);
                break;
            case "Show_Map_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Map").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().ShouldFollow = false;
                break;
            case "Close_Map_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("Map").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<AugmentedImageExampleController>().ShouldFollow = true;
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").gameObject.SetActive(true);
                break;
            case "Hej_Speech_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("HejSpeechElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FollowMe").gameObject.SetActive(true);
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
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(true);
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
                GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").transform.GetComponent<Animator>().Play("catAnim_21");
                StartCoroutine(OpenTheThirdQuiz());
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
                GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").transform.GetComponent<Animator>().Play("catAnim_25");
                StartCoroutine(OpenTheFourthQuiz());
                break;
            case "Close_Third_Backpack_Btn":
                if (backpackFrom == "FourthQuizImage")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").gameObject.SetActive(true);
                    backpackFrom = "";
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBackpack").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdAfter").gameObject.SetActive(true);
                }
                break;
            case "Fourth_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthAfter").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthBackpack").gameObject.SetActive(true);
                break;
            case "Ready_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthBackpack").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").gameObject.SetActive(true);
                break;
            case "Final_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FinalBackpack").gameObject.SetActive(true);
                break;
            case "Close_Final_Backpack_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FinalBackpack").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("AttentionArrow").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").gameObject.SetActive(true);
                break;
            case "07_Btn":
                Debug.Log("belemegy");
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
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").GetComponent<InputField>().text = name;
    }

    IEnumerator OpenTheSecondQuiz()
    {
        yield return new WaitForSeconds(18);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").gameObject.SetActive(true);
    }

    IEnumerator OpenTheThirdQuiz()
    {
        yield return new WaitForSeconds(10);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBefore").gameObject.SetActive(true);
    }

    IEnumerator OpenTheFourthQuiz()
    {
        yield return new WaitForSeconds(8);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").gameObject.SetActive(true);
    }
}
