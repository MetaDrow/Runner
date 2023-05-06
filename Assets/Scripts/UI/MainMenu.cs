using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI _hightScoreText;
    [SerializeField] internal Fader _fader;
    [SerializeField] internal Animator _animator;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _controlPanel;


    [DllImport("__Internal")]
    private static extern void ShowAdv();
    private bool _isActive;
    private void Awake()
    {
        _audioSource.Play();
    }

    private void Start()
    {
        //ShowAdv();
        _controlPanel.SetActive(false);
        _isActive = false;
    }

    private void Update()
    {
        _hightScoreText.text = CountManager._instance._hightScore.ToString();
    }

    public void Play()
    {
        _animator.Play("RunningMenu");
        _fader.FadeToNextLevel();
        _audioSource.Stop();
    }

    public void ControlPanelActivate()
    {
        if (_controlPanel != null)
        {
            _isActive = _controlPanel.activeSelf;
            _controlPanel.SetActive(!_isActive);
        }
    }
}

