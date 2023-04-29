using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class UILoadManager : MonoBehaviour
{
    public AbstractCharacter _character;
    public PlatformFactory _platform;
    public DeathMenu _deathMenu;
    public Camera _camera;
    public TimerCountdown _timer;
    public Pause _pause;
    public AudioSource _audio;
    internal static bool _onPause = false;

    private void OnEnable()
    {
        EventManager.onDeathTriggerEnter += DeathTrigger;
    }

    private void OnDisable()
    {
        EventManager.onDeathTriggerEnter -= DeathTrigger;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _onPause == false)
        {
            Pause();
        }
    }
    public void MainMenu()
    {
        _onPause = false;
        ResumeGame();
        CountManager._coin = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause()
    {
        if (_onPause == false)
        {
            _character._audioRun.Pause();
            _onPause = true;
            PauseGame();
            _pause._pauseUI.SetActive(true);
            _character._audioRun.enabled = false;
        }
    }
    internal void DeathTrigger()
    {
        _onPause = true;
        _character._isPlay = false;
        _character._animator.Play("Death");

        PauseGame();
        _audio.Pause();
        _character._audioRun.Pause();
        StartCoroutine(DeathPanel());

    }

    IEnumerator DeathPanel()
    {
        yield return new WaitForSecondsRealtime(2f);
        this._character.transform.position = _platform.PrefabSpawned[2]._playerSpawnPosition.transform.position;
        this._character._line = 0;
        this._character._targetPos = this._character._rb.transform.position;
        CountManager._instance._gameUI.SetActive(false);
        _deathMenu.deathPanel.SetActive(true);
        _character._isPlay = true;
    }

    public void Resume()
    {
        if (CountManager._coin >= 100)
        {
            _onPause = true;
            _deathMenu.deathPanel.SetActive(false);
            CountManager._instance._gameUI.SetActive(true);
            StartCoroutine(ResumeGamePause());
        }
    }

    public void ResumeOnPause()
    {
        _onPause = false;
        _deathMenu.deathPanel.SetActive(false);
        _pause._pauseUI.SetActive(false);
        ResumeGame();
        CountManager._instance._gameUI.SetActive(true);
        _character._isPlay = true;
        _character._audioRun.Play();
    }

    IEnumerator ResumeGamePause()
    {
        _character._isPlay = false;
        _character._animator.SetBool("Run", false);
        _timer._timer.SetActive(true);
        _timer.StartCorutine();

        yield return new WaitForSecondsRealtime(5f);
        ResumeGame();
        _audio.Play();
        _character._audioRun.Play();
        CountManager._coin -= 100;
        _character._animator.SetBool("Run", true);
        _character._isPlay = true;
        _onPause = false;

    }

    public void Restart()
    {
        _onPause = false;
        _audio.Stop();
        ResumeGame();

        CountManager._coin = 0;
        SceneManager.LoadScene("LVL");
        CountManager._instance._gameUI.SetActive(true);
    }

    internal void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
