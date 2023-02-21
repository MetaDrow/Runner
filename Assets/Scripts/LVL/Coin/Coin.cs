using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform Begin;
    public Transform End;
    [SerializeField] private float speed;
    public GameObject CoinPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }
}
