using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeLogger : MonoBehaviour
{
    private float zOffset = 10;
    private SwipeDirection direction;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
    
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        if (data.directionText == "Left")
        {
            if(sceneName == "Slider_First")
            {
                SceneManager.LoadScene("Slider_Second");
            } else if(sceneName == "Slider_Second")
            {
                SceneManager.LoadScene("Slider_Third");
            }
        } else if(data.directionText == "Right")
        {
            if (sceneName == "Slider_Second")
            {
                SceneManager.LoadScene("Slider_First");
            }
            else if (sceneName == "Slider_Third")
            {
                SceneManager.LoadScene("Slider_Second");
            }
        }
    }
}