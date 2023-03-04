using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {


        if (this.CompareTag("Coin") && collision.CompareTag("Player"))
        {
            CoinCount.coin++;
            Destroy(this.gameObject);
        }

    }
}
