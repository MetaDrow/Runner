using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI ScoreText;
    [SerializeField] internal TextMeshProUGUI CoinText;

    public GameObject deathPanel;
   // public ScoreManager coin;

    public AudioSource _audio;

    private void Awake()
    {
        deathPanel.SetActive(false);
        
    }
    
    void PauseGame()
    {
        Time.timeScale = 0;
    }    
    void ResumeGame()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        ScoreText.text = ScoreManager.instance.score.ToString();
        CoinText.text = ScoreManager.coin.ToString();
    }

    public void MainMenu()
    {
        ResumeGame();
        ScoreManager.coin = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        _audio.Stop();
        ResumeGame();

        ScoreManager.coin = 0;
        SceneManager.LoadScene("LVL");
        ScoreManager.instance._gameUI.SetActive(true);
    }

    public void Resume()
    {
        if(ScoreManager.coin >=1)
        {

            deathPanel.SetActive(false);
            ScoreManager.instance._gameUI.SetActive(true);

            StartCoroutine(ResumeGamePause());

        }

    }

    IEnumerator ResumeGamePause()
    {
        yield return new WaitForSecondsRealtime(5f);
        ResumeGame();
        _audio.Play();
        ScoreManager.coin -= 1;
    }
}
