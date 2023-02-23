using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] internal Transform Begin;
    [SerializeField] internal Transform End;
    [SerializeField] internal Transform spawnLeft;
    [SerializeField] internal Transform spawnRight;
    [SerializeField] internal Transform spawnCenter;

    [SerializeField] private float _speed;


    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
    }
}