using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI _hightScoreText;

    [SerializeField] internal Fader _fader;
    [SerializeField] internal Animator _animator;

    [SerializeField] AudioSource _audioSource;

    [SerializeField] GameObject _controlPanel;



    private bool _isActive;
    private void Start()
    {
        _controlPanel.SetActive(false);
        _isActive = false;
        _audioSource.Play();

    }
    private void Update()
    {
        _hightScoreText.text = CountManager.instance.hightScore.ToString();


    }
    public void Play()
    {
        _animator.Play("RunningMenu");
       _fader.FadeToNextLevel();
        _audioSource.Stop();
        // _fader.OnFadeComplete();
        // SceneManager.LoadScene("LVL");

    }

   public  void ControlPanelActivate()
    {
        if(_controlPanel != null)
        {
   
            _isActive = _controlPanel.activeSelf;
            _controlPanel.SetActive(!_isActive);
        }



    }


}

