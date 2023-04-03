using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Coin") && other.CompareTag("Player"))
        {
            CountManager.coin++;
            Destroy(this.gameObject);
        }
    }
}
