using TMPro;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    [SerializeField] internal static CountManager _instance;
    [SerializeField] internal TextMeshProUGUI _scoreText;
    [SerializeField] internal TextMeshProUGUI _hightScoreText;
    [SerializeField] internal AbstractCharacter _character;

    public float _score;
    internal int _hightScore;

    ///////////////////////////////////////
    [SerializeField] internal TextMeshProUGUI _coinText;
    [SerializeField] internal static int _coin;

    public GameObject _gameUI;


    private void OnEnable()
    {
        EventManager.onCoinTriggerEnter += CoinAdd;
    }
    private void OnDisable()
    {
        EventManager.onCoinTriggerEnter -= CoinAdd;
    }
    private void Awake()
    {
        _instance = this;
        Reset();

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            _hightScore = PlayerPrefs.GetInt("SaveScore");
        }
    }

    void FixedUpdate()
    {
        AddScore();
        ScoreCount();
        CoinCount();
    }

    void AddScore()
    {
        _score = (int)_character.transform.position.z;
        _score++;
        AddHightScore();
    }

    void AddHightScore()
    {
        if (_score > _hightScore)
        {
            _hightScore = (int)_score;
        }
    }

    private void Reset()
    {
        _score = 0;
    }
    
    void CoinAdd()
    {
        _coin++;
    }

    void ScoreCount()
    {

        _scoreText.text = _score.ToString();
        _hightScoreText.text = _hightScore.ToString();
    }
    void CoinCount()
    {
        _coinText.text = _coin.ToString();
    }
}
