using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstQuizController : MonoBehaviour
{
    public void Check()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Yes_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstGift").gameObject.SetActive(true);
                StartCoroutine(ForwardAfterSeconds());
                break;
            case "Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Yes_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("No_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("HelpImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Close_Help_Btn").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("HelpImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Close_Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Yes_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("No_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Help_Btn").gameObject.SetActive(true);
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("WrongAnswerImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Try_Again_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Yes_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("No_Btn").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Help_Btn").gameObject.SetActive(true);
                break;
            default:
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizImage").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Yes_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("No_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Help_Btn").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("WrongAnswerImage").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("Try_Again_Btn").gameObject.SetActive(true);
                break;
        }


    }
    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstGift").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstAfter").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("Backpack_Btn").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("Continue_Btn").gameObject.SetActive(true);
    }
}
