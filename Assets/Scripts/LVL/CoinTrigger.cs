using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Coin") && other.CompareTag("Player"))
        {
            EventManager._instance.Coin();
            //CountManager.coin++;
            Destroy(this.gameObject);
        }
    }
}
