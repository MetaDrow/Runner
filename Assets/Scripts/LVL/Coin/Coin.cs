using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform Begin;
    public Transform End;

    public GameObject CoinPrefab;

    [SerializeField] private float _speed;

    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
    }
}
