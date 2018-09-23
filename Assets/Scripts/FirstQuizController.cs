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
                GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").transform.GetComponent<Animator>().Play("catAnim_13");
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstGift").gameObject.SetActive(true);
                StartCoroutine(ForwardAfterSeconds());
                break;
            case "Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("HelperElements").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("HelperElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizElements").gameObject.SetActive(true);
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("WrongAnswerElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizElements").gameObject.SetActive(true);
                break;
            default:
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("FirstQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").Find("WrongAnswerElements").gameObject.SetActive(true);
                break;
        }


    }
    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstGift").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstAfter").gameObject.SetActive(true);
    }
}
