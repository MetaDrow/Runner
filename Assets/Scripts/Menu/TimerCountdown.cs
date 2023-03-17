using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI _timerText;
    [SerializeField] internal GameObject _timer;
    private readonly int _timerValue= 5;

    void Start()
    {

         _timer.SetActive(false);
    }

    public void StartCorutine()
    {
        StartCoroutine(PauseWait(_timerValue));
    }
    public IEnumerator PauseWait(int _timerValue)
    {
        int count = 0;

        while (count< _timerValue)
        {
            var text = _timerValue - count;

            _timerText.text= text.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count++;

        }


        _timer.SetActive(false);

    }



}
