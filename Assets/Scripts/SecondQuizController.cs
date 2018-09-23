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
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("HelperElements").gameObject.SetActive(true);
                break;
            case "Backpack_Btn":
                GameObject.FindGameObjectWithTag("Controller").transform.GetComponent<BtnController>().backpackFrom = "SecondQuizImage";
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstBackpack").gameObject.SetActive(true);
                break;
            case "Close_Help_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("HelperElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(true);
                break;
            case "Try_Again_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(true);
                break;
            case "German_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerElements").gameObject.SetActive(true);
                break;
            case "Danish_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerElements").gameObject.SetActive(true);
                break;
            case "English_Btn":
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("SecondQuizElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("SecondQuiz").Find("WrongAnswerElements").gameObject.SetActive(true);
                break;
            case "Russian_Btn":
                GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").transform.GetComponent<Animator>().Play("catAnim_20");
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
