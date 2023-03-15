using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI _timerText;
    [SerializeField] private int _delay = 3;
    [SerializeField] public  GameObject _timer;
    void Start()
    {

        //_timer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        
        while (_delay> 0)
        {
            _delay--;
            _timerText.text= _delay.ToString();
            yield return new WaitForSecondsRealtime(1);

        }
    


        yield return null;
    }


}
