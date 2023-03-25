using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI _hightScoreText;

    [SerializeField] internal Fader _fader;
    [SerializeField] internal Animator _animator;

    private void Update()
    {
        _hightScoreText.text = ScoreManager.instance.hightScore.ToString();
    }
    public void Play()
    {
        _animator.Play("RunningMenu");
       _fader.FadeToNextLevel();
        // _fader.OnFadeComplete();
        // SceneManager.LoadScene("LVL");

    }

}

