using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    [SerializeField] internal TextMeshProUGUI coinText;
    [SerializeField] internal static int coin;



    void FixedUpdate()
    {
        Count();
    }

    void Count()
    {
        coinText.text = coin.ToString();

    }
}
