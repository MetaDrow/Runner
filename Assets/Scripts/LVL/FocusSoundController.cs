using UnityEngine;

public class FocusSoundController : MonoBehaviour
{
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

        if(EventManager._death != true)
        {
            EventManager._instance.Pause();
        }

       // AudioListener.volume = silence ? 0 : 1;
    }

}
