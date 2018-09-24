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
                Translation("FirstSlider");
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").gameObject.SetActive(true);
                break;
            case "First_Next_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").gameObject.SetActive(false);
                Translation("SecondSlider");
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").gameObject.SetActive(true);
                break;
            case "Second_Next_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").gameObject.SetActive(false);
                Translation("ThirdSlider");
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(true);
                break;
            case "Start_Btn":
                catName = GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").Find("Text").GetComponent<Text>().text;
                if (catName == "")
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").gameObject.SetActive(false);
                    Translation("MissingCatNameElements");
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

    public void Translation (string screen)
    {
        if (PlayerPrefs.GetString("appLang") != null)
        {
            if (PlayerPrefs.GetString("appLang") == "English")
            {
                switch (screen)
                {
                    case "FirstSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Btn_Txt").GetComponent<Text>().text = "Continue";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text").GetComponent<Text>().text = "You are just in time!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (1)").GetComponent<Text>().text = "In the museum,\nthere is a forgotten\nbut still functioning bomb.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (2)").GetComponent<Text>().text = "The only chance of\nstopping the disaster\nis to prove your courage!";
                        break;
                    case "SecondSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Btn_Txt").GetComponent<Text>().text = "Continue";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text").GetComponent<Text>().text = "During the mission,\nyou will get some\nquestions.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text (1)").GetComponent<Text>().text = "You need to answer properly,\nas this is the only way\nto find the code which will\ndisarm the bomb.";
                        break;
                    case "ThirdSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Random_Btn_Txt").GetComponent<Text>().text = "Random name";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Save_Btn_Txt").GetComponent<Text>().text = "Save";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text").GetComponent<Text>().text = "Before we begin,\nyou will need an assistant,\nwho will help you\nfind the clues.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text (1)").GetComponent<Text>().text = "How are you going to call it?";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").Find("Placeholder").GetComponent<Text>().text = "Type a name here...";
                        break;
                    case "MissingCatNameElements":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Btn_Txt").GetComponent<Text>().text = "Try again";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text").GetComponent<Text>().text = "Oops!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text (1)").GetComponent<Text>().text = "Your partner needs\na name!";
                        break;
                    case "FirstClue":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Btn_Txt").GetComponent<Text>().text = "Show on map";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Text").GetComponent<Text>().text = "Follow my paws to find me\nand save the visitors!";
                        break;
                    default:
                        break;
                }
            } else if (PlayerPrefs.GetString("appLang") == "German")
            {
                switch (screen)
                {
                    case "FirstSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Btn_Txt").GetComponent<Text>().text = "Fortsetzen";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text").GetComponent<Text>().text = "Du bist gerade rechtzeitig!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (1)").GetComponent<Text>().text = "Im Museum gibt es\neine vergessene, aber immer noch funktionierende Bombe.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (2)").GetComponent<Text>().text = "Die einzige Chance,\ndas Desaster zu stoppen,\nist der Mut!";
                        break;
                    case "SecondSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Btn_Txt").GetComponent<Text>().text = "Fortsetzen";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text").GetComponent<Text>().text = "Während der Mission\nwerden Sie einige\nFragen bekommen.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text (1)").GetComponent<Text>().text = "Sie müssen richtig antworten,\nda dies der einzige Weg ist,\nden Code zu finden,\nder die Bombe entschärft.";
                        break;
                    case "ThirdSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Random_Btn_Txt").GetComponent<Text>().text = "Zufälliger Name";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Save_Btn_Txt").GetComponent<Text>().text = "Rettung";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text").GetComponent<Text>().text = "Bevor wir anfangen,\nbrauchen Sie einen\nAssistenten, der Ihnen\nhilft, die Hinweise zu finden.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text (1)").GetComponent<Text>().text = "Wie wirst du es nennen?";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").Find("Placeholder").GetComponent<Text>().text = "Zufälliger Name...";
                        break;
                    case "MissingCatNameElements":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Btn_Txt").GetComponent<Text>().text = "Versuch es noch einmal";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text").GetComponent<Text>().text = "Hoppla!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text (1)").GetComponent<Text>().text = "Ihr Partner braucht\neinen Namen!";
                        break;
                    case "FirstClue":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Btn_Txt").GetComponent<Text>().text = "Auf der Karte anzeigen";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Text").GetComponent<Text>().text = "Folge meinen Pfoten,\num mich zu finden\nund rette die Besucher!";
                        break;
                    default:
                        break;
                }
            } else
            {
                switch (screen)
                {
                    case "FirstSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Btn_Txt").GetComponent<Text>().text = "Fortsætte";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text").GetComponent<Text>().text = "Du er lige i tide!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (1)").GetComponent<Text>().text = "I museet er der en glemt\nmen stadig fungerende\nbombe.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstSlider").Find("Text (2)").GetComponent<Text>().text = "Den eneste chance for\nat stoppe katastrofen\ner at bevise dit mod!";
                        break;
                    case "SecondSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Btn_Txt").GetComponent<Text>().text = "Fortsætte";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text").GetComponent<Text>().text = "Under missionen\nfår du nogle\nspørgsmål.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondSlider").Find("Text (1)").GetComponent<Text>().text = "Du skal svare korrekt,\nda det er den eneste måde\nat finde koden på,\nsom vil afvæbne bomben.";
                        break;
                    case "ThirdSlider":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Random_Btn_Txt").GetComponent<Text>().text = "Tilfældigt navn";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Save_Btn_Txt").GetComponent<Text>().text = "Gemme";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text").GetComponent<Text>().text = "Før vi begynder,\nhar du brug for en assistent,\nhvem vil hjælpe dig med\nat finde sporene.";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Text (1)").GetComponent<Text>().text = "Hvordan skal du kalde det?";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdSlider").Find("Cat_Name_Input").Find("Placeholder").GetComponent<Text>().text = "Tilfældigt navn...";
                        break;
                    case "MissingCatNameElements":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Btn_Txt").GetComponent<Text>().text = "Prøv igen";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text").GetComponent<Text>().text = "Ups!";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("MissingCatNameElements").Find("Text (1)").GetComponent<Text>().text = "Din partner har brug\nfor et navn!";
                        break;
                    case "FirstClue":
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Btn_Txt").GetComponent<Text>().text = "Vis på kort";
                        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstClue").Find("Text").GetComponent<Text>().text = "Følg mine poter for at finde\nmig og gem de besøgende!";
                        break;
                    default:
                        break;
                }
            }
               
        }
            
    }
}
