using UnityEngine;

public class FocusSoundController : MonoBehaviour
{


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    void OnApplicationFocus(bool hasFocus)
    {

        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {

        Silence(isPaused);
    }

    private void Silence(bool silence)
    {


        AudioListener.pause = silence;
        if(silence == true)
        {
            EventManager._instance.Pause();
        }
        // Or / And
        AudioListener.volume = silence ? 0 : 1;


    }

}
