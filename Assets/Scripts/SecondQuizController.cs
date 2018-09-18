using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GoogleARCore.Examples.AugmentedImage;

public class SecondQuizController : MonoBehaviour {

    public void SecondCheck()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("HelpImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Close_Help_Btn").gameObject.SetActive(true);
                break;
            case "Backpack_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<BtnController>().backpackFrom = "SecondQuizImage";
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstBackpack").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("HelpImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Close_Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(true);
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Try_Again_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(true);
                break;
            case "German_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Try_Again_Btn").gameObject.SetActive(true);
                break;
            case "Danish_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Try_Again_Btn").gameObject.SetActive(true);
                break;
            case "English_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Backpack_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("German_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Danish_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Russian_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("English_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("Try_Again_Btn").gameObject.SetActive(true);
                break;
            case "Russian_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondGift").gameObject.SetActive(true);
                StartCoroutine(ForwardAfterSeconds());
                break;
            default:
                break;
        }
    }
    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondGift").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondAfter").gameObject.SetActive(true);
    }
}
