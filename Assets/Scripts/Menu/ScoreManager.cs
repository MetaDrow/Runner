using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] internal static ScoreManager instance;
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
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            hightScore = PlayerPrefs.GetInt("SaveScore");

        }
        

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
            PlayerPrefs.SetInt("SaveScore", hightScore);

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
