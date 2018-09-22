using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BombController : MonoBehaviour {
    public Sprite myFirstImage; 
    public Sprite mySecondImage;
    public Sprite myThirdImage;
    public Sprite myFourthImage;
    public Sprite myFifthImage;
    public Sprite mySixthImage;
    public Sprite mySeventhImage;
    public Sprite myEighthImage;
    public Sprite myNinthImage;
    public Sprite myZeroImage;
    public Sprite slash;

    private List<string> correctDigits = new List<string>();
    private List<string> selectedDigits = new List<string>();

    private Image actualPosition;

    public void Start()
    {
        correctDigits.Add("1");
        correctDigits.Add("9");
        correctDigits.Add("4");
        correctDigits.Add("0");
        actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FirstDigitImage").GetComponent<Image>();
    }

    public void SetActualPosition()
    {
        if (selectedDigits.Count == 0)
        {
            actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FirstDigitImage").GetComponent<Image>();
        }
        else if (selectedDigits.Count == 1)
        {
            actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("SecondDigitImage").GetComponent<Image>();
        }
        else if (selectedDigits.Count == 2)
        {
            actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("ThirdDigitImage").GetComponent<Image>();
        }
        else if (selectedDigits.Count == 3)
        {
            actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FourthDigitImage").GetComponent<Image>();
        }
    }

    public void BtnController ()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("AttentionArrow").gameObject.SetActive(false);
        SetActualPosition();
        if (selectedDigits.Count < 4)
        {
            switch (buttonName)
            {
                case "00_Btn":
                    actualPosition.sprite = myZeroImage;
                    selectedDigits.Add("0");
                    break;
                case "01_Btn":
                    actualPosition.sprite = myFirstImage;
                    selectedDigits.Add("1");
                    break;
                case "02_Btn":
                    actualPosition.sprite = mySecondImage;
                    selectedDigits.Add("2");
                    break;
                case "03_Btn":
                    actualPosition.sprite = myThirdImage;
                    selectedDigits.Add("3");
                    break;
                case "04_Btn":
                    actualPosition.sprite = myFourthImage;
                    selectedDigits.Add("4");
                    break;
                case "05_Btn":
                    actualPosition.sprite = myFifthImage;
                    selectedDigits.Add("5");
                    break;
                case "06_Btn":
                    actualPosition.sprite = mySixthImage;
                    selectedDigits.Add("6");
                    break;
                case "07_Btn":
                    actualPosition.sprite = mySeventhImage;
                    selectedDigits.Add("7");
                    break;
                case "08_Btn":
                    actualPosition.sprite = myEighthImage;
                    selectedDigits.Add("8");
                    break;
                case "09_Btn":
                    actualPosition.sprite = myNinthImage;
                    selectedDigits.Add("9");
                    break;
                case "Back_Btn":
                    Back();
                    break;
                case "Clear_Btn":
                    Clear();
                    break;
            }
        }

        if (selectedDigits.Count == 4)
        {
            StartCoroutine(ForwardAfterSeconds());
        }
    }

    IEnumerator ForwardAfterSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        Check();
    }

    public void Check()
    {
        if (selectedDigits.Count != correctDigits.Count)
        {
            Clear();
        } else
        {
            for (int i = 0; i < selectedDigits.Count; i++)
            {
                if (correctDigits[i] != selectedDigits[i])
                {
                    Clear();
                    GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("AttentionArrow").gameObject.SetActive(true);
                }
            }
            if(!GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("AttentionArrow").gameObject.active)
            {
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Cnv").transform.Find("DeactivatedBombElements").gameObject.SetActive(true);
                StartCoroutine(ForwardToTheLastScreen());
            }
        } 
    }

    IEnumerator ForwardToTheLastScreen()
    {

        yield return new WaitForSeconds(2.5f);

        GameObject.FindGameObjectWithTag("Cnv").transform.Find("DeactivatedBombElements").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("Congratulation").gameObject.SetActive(true);
    }

    public void Clear()
    {
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FirstDigitImage").GetComponent<Image>().sprite = slash;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("SecondDigitImage").GetComponent<Image>().sprite = slash;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("ThirdDigitImage").GetComponent<Image>().sprite = slash;
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FourthDigitImage").GetComponent<Image>().sprite = slash;
        actualPosition = GameObject.FindGameObjectWithTag("Cnv").transform.Find("BombElements").Find("FirstDigitImage").GetComponent<Image>();
        selectedDigits.Clear();
    }

    public void Back()
    {
        if(selectedDigits.Count > 0 )
        {
            selectedDigits.RemoveAt(selectedDigits.Count - 1);
            SetActualPosition();
            actualPosition.sprite = slash;
        } else
        {
            SetActualPosition();
            actualPosition.sprite = slash;
        }
        
    }
}
