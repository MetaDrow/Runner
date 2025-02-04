using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI ScoreText;
    [SerializeField] internal TextMeshProUGUI CoinText;
    public GameObject deathPanel;

    private void Awake()
    {
        deathPanel.SetActive(false);
    }

    void Update()
    {
        ScoreText.text = CountManager._instance._score.ToString();
        CoinText.text = CountManager._coin.ToString();
    }
}
