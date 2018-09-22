using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GoogleARCore.Examples.AugmentedImage;
using UnityEngine.UI;

public class FourthQuizController : MonoBehaviour {

    private readonly string[] rightLettersPosition = { "01_Btn", "02_Btn", "06_Btn", "10_Btn", "14_Btn", "15_Btn", "16_Btn", "12_Btn", "08_Btn"};
    private List<string> selectedLetters = new List<string>();

	public void Check()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
       
        if(selectedLetters.Count < rightLettersPosition.Length)
        {
            if (buttonName == rightLettersPosition[selectedLetters.Count])
            {
                if(selectedLetters.Count < rightLettersPosition.Length-1)
                {
                    var nextButton = GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("FourthQuizElements").Find(rightLettersPosition[selectedLetters.Count + 1]);
                    ColorBlock colorBlock = nextButton.GetComponent<Button>().colors;
                    colorBlock.pressedColor = new Color32(26, 129, 153, 153);
                    nextButton.GetComponent<Button>().colors = colorBlock;
                }

                selectedLetters.Add(buttonName);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("FourthQuizElements").Find(buttonName).GetComponent<Image>().color = new Color32(26, 129, 153, 255);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("FourthQuizElements").Find(buttonName).Find("Text").GetComponent<Text>().color = new Color32(247, 247, 239, 255);

                if(selectedLetters.Count == rightLettersPosition.Length)
                {
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthGift").gameObject.SetActive(true);
                    StartCoroutine(ForwardAfterSeconds());
                }
                
            }
        }
    }


    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthGift").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthAfter").gameObject.SetActive(true);
    }

    public void BtnController()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("FourthQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("HelperElements").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("HelperElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").Find("FourthQuizElements").gameObject.SetActive(true);
                break;
            case "Backpack_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<BtnController>().backpackFrom = "FourthQuizImage";
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FourthQuiz").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("ThirdBackpack").gameObject.SetActive(true);
                break;
        }
    }

}

