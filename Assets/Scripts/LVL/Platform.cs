using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] internal Transform Begin;
    [SerializeField] internal Transform End;

    [SerializeField] private float speed;


    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }
}