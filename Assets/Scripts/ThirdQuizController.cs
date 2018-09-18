using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThirdQuizController : MonoBehaviour {

    private string[] firstOptions = { "Because the war started", "Because her parents didn't allow them", "Because her sister didn't want to play with her" };
    private string[] secondOptions = { "Big machines",  "Trucks", "Teddy bears"};
    private string[] thirdOptions = { "The soldiers put ugly bunkers in the dunes", "Nothing", "It became a pasture for the cows" };

    private int currentFirstOptionIndex;
    private int currentSecondOptionIndex;
    private int currentThirdOptionIndex;

    private void Start()
    {
        System.Random random = new System.Random();
        int firstOptionIndex = random.Next(firstOptions.Length);
        string currentFirstOption = firstOptions[firstOptionIndex];
        currentFirstOptionIndex = firstOptionIndex;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().text = currentFirstOption;

        int secondOptionIndex = random.Next(secondOptions.Length);
        string currentSecondOption = secondOptions[secondOptionIndex];
        currentSecondOptionIndex = secondOptionIndex;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().text = currentSecondOption;

        int thirdOptionIndex = random.Next(thirdOptions.Length);
        string currentThirdOption = thirdOptions[thirdOptionIndex];
        currentThirdOptionIndex = thirdOptionIndex;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().text = currentThirdOption;
    }

    public void GetPrevOption()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch(buttonName)
        {
            case "First_Left_Btn":
                if (currentFirstOptionIndex == 0)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentFirstOptionIndex = firstOptions.Length - 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().text = firstOptions[currentFirstOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentFirstOptionIndex -= 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().text = firstOptions[currentFirstOptionIndex];
                }
                break;
            case "Second_Left_Btn":
                if (currentSecondOptionIndex == 0)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentSecondOptionIndex = secondOptions.Length - 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().text = secondOptions[currentSecondOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentSecondOptionIndex -= 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().text = secondOptions[currentSecondOptionIndex];
                }
                break;
            case "Third_Left_Btn":
                if (currentThirdOptionIndex == 0)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentThirdOptionIndex = thirdOptions.Length - 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().text = thirdOptions[currentThirdOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentThirdOptionIndex -= 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().text = thirdOptions[currentThirdOptionIndex];
                }
                break;
        }
    }

    public void GetNextOption()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "First_Right_Btn":
                if (currentFirstOptionIndex == firstOptions.Length - 1)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentFirstOptionIndex = 0;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().text = firstOptions[currentFirstOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentFirstOptionIndex += 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().text = firstOptions[currentFirstOptionIndex];
                }
                break;
            case "Second_Right_Btn":
                if (currentSecondOptionIndex == secondOptions.Length - 1)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentSecondOptionIndex = 0;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().text = secondOptions[currentSecondOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentSecondOptionIndex += 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().text = secondOptions[currentSecondOptionIndex];
                }
                break;
            case "Third_Right_Btn":
                if (currentThirdOptionIndex == thirdOptions.Length - 1)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentThirdOptionIndex = 0;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().text = thirdOptions[currentThirdOptionIndex];
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 0);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(26, 129, 153, 255);
                    currentThirdOptionIndex += 1;
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().text = thirdOptions[currentThirdOptionIndex];    
                }
                break;
        }
    }

    public void BtnController()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("HelperElements").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("HelperElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").gameObject.SetActive(true);
                break;
            case "Backpack_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<BtnController>().backpackFrom = "ThirdQuizImage";
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondBackpack").gameObject.SetActive(true);
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("WrongAnswerElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").gameObject.SetActive(true);
                break;
        }
    }

    public void Check()
    {
        if(currentFirstOptionIndex != 0 || currentSecondOptionIndex != 2 || currentThirdOptionIndex != 0)
        {
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").gameObject.SetActive(false);

            if(currentFirstOptionIndex != 0)
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 100);
            } else
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("First_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("FirstPanel").GetComponent<Image>().color = new Color32(20, 226, 0, 100);
            }
            if (currentSecondOptionIndex != 2)
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 100);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Second_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("SecondPanel").GetComponent<Image>().color = new Color32(20, 226, 0, 100);
            }
            if (currentThirdOptionIndex != 0)
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(255, 11, 11, 100);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("Third_Txt").GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("ThirdQuizElements").Find("ThirdPanel").GetComponent<Image>().color = new Color32(20, 226, 0, 100);
            }

            GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").Find("WrongAnswerElements").gameObject.SetActive(true);
        } else
        {
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdQuiz").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdGift").gameObject.SetActive(true);
            StartCoroutine(ForwardAfterSeconds());
        }
    }

    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdGift").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdAfter").gameObject.SetActive(true);
    }
}
