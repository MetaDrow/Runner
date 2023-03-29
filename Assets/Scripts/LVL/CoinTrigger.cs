using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (this.CompareTag("Coin") && other.CompareTag("Player"))
        {

            ScoreManager.coin++;
            Destroy(this.gameObject);
        }

    }


}
