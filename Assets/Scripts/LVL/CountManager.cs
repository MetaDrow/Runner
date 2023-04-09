using TMPro;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    [SerializeField] internal static CountManager instance;
    [SerializeField] internal TextMeshProUGUI ScoreText;
    [SerializeField] internal TextMeshProUGUI HightScoreText;
    [SerializeField] internal AbstractCharacter _character;

    public float score;
    internal int hightScore;

    ///////////////////////////////////////
    [SerializeField] internal TextMeshProUGUI coinText;
    [SerializeField] internal static int coin;

    public GameObject _gameUI;

    private void Awake()
    {
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
        HightScoreText.text = hightScore.ToString();

        CoinCount();
    }

    void AddScore()
    {
        score = (int)_character.transform.position.z;
        score++;
        AddHightScore();
    }

    void AddHightScore()
    {
        if (score > hightScore)
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
