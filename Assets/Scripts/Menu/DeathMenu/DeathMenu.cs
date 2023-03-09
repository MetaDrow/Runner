using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI ScoreText;

    public GameObject deathPanel;
    public ScoreManager coin;

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
    }

    public void Resume()
    {
        if(ScoreManager.coin >=10)
        {
            deathPanel.SetActive(false);
            ResumeGame();
            _audio.Play();
            ScoreManager.coin -= 10;
        }

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("Finish"))
        {
            PauseGame();
            deathPanel.SetActive(true);


        }
    }
    */
}
