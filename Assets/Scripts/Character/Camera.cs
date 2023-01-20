
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public Transform player;
   public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {

        transform.position = player.position + offset;
    }
}