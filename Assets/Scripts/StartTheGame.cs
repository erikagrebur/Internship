using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.AugmentedImage;

public class StartTheGame : MonoBehaviour {

    private bool turn = false;

    private Transform Target;
    private float RotationSpeed = 2.0f;
    private float turningTime = 0f;
    private float speed = 0.3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(turn)
        {
            //Start the turning animation (for a more lifelike movement)
            GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("turn_left");
            //The from value will be the rotation of the cat
            Quaternion from = Quaternion.Euler(GameObject.FindGameObjectWithTag("Cat").transform.eulerAngles);
            //The cat will rotate to the chair
            Quaternion to = Quaternion.Euler(new Vector3(0, -160, 0));
            turningTime += Time.deltaTime * speed;
            GameObject.FindGameObjectWithTag("Cat").transform.rotation = Quaternion.Lerp(from, to, turningTime);

            if(turningTime >= 1)
            {
                Next_01();
                turn = false;
            }
        }
	}

    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FollowMe").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("Let_Start_Btn").gameObject.SetActive(false);

        StandUp();
    }

    public void StandUp()
    {
        GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("idle_02_copy_sit_before_stand_up");

        GameObject.FindGameObjectWithTag("Cat").transform.GetComponent<AugmentedImageVisualizer>().FollowTheCamera = false;

        turn = true;

        //GameObject.FindGameObjectWithTag("Cat").transform.eulerAngles = new Vector3(0, -210, 0);
        //GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("turn_left");
        //GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("test02");

    }

    public void Next_01()
    {
        GameObject.FindGameObjectWithTag("Cat").transform.Find("cat_anim_fbx").GetComponent<Animator>().Play("catAnim_01");
        StartCoroutine(OpenTheFirstQuiz());
    }

    IEnumerator OpenTheFirstQuiz()
    {
        yield return new WaitForSeconds(14);
        GameObject.FindGameObjectWithTag("Cnv").transform.Find("FirstQuiz").gameObject.SetActive(true);
    }
}
