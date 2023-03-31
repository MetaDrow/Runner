using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;
using System.IO;

public class CountManager : MonoBehaviour
{
    [SerializeField] internal static CountManager instance;
    [SerializeField] internal TextMeshProUGUI ScoreText;
    [SerializeField] internal TextMeshProUGUI HightScoreText;
    [SerializeField] internal AbstractCharacter _character;

    private float time;
    public  float score;
    internal int hightScore;

    ///////////////////////////////////////
    [SerializeField] internal TextMeshProUGUI coinText;
    [SerializeField] internal static int coin;

    public GameObject _gameUI;




    private void Awake()
    {

        //PlayerPrefs.DeleteAll();
        instance = this;
        Reset();

        /*
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            hightScore = PlayerPrefs.GetInt("SaveScore");

        }
        */
        // LoadScore();

        LoadScore();
    }

    public void SaveScore()
    {
        SaveSystem.SaveHightScore(this);
    }
     
    public void LoadScore() 
    {
        PlayerScore playerScore = SaveSystem.LoadScore();

        hightScore = playerScore.HightScore;
    }
    void FixedUpdate()
    {
        instance.AddScore();

        ScoreText.text = score.ToString();
        HightScoreText.text= hightScore.ToString();

        CoinCount();
        /*
        if(PlayerPrefs.GetInt("score")<= hightScore)
        {
            PlayerPrefs.SetInt("score", hightScore);
        }
        HightScoreText.text = PlayerPrefs.GetInt("score").ToString();
        */

    }

    void AddScore()
    {
         score = (int)_character.transform.position.z;
        score++;
        AddHightScore();




    }

    void AddHightScore()
    {
        if(score > hightScore)
        {
            hightScore = (int)score;
            //SaveScore();
            //PlayerPrefs.SetInt("SaveScore", hightScore);

        }
    }

    private void Reset()
    {
        score = 0;
    }

    void CoinCount()
    {
        coinText.text = coin.ToString();

    }
}
