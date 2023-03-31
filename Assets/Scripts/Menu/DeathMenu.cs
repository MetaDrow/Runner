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



    private void Awake()
    {
        deathPanel.SetActive(false);
        
    }

    void Update()
    {
        ScoreText.text = CountManager.instance.score.ToString();
        CoinText.text = CountManager.coin.ToString();
    }


}
