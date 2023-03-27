using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRay : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    public Transform _pointer;
    Action _action;
    void Start()
    {
        //_action = Ray();
    }


    void FixedUpdate()
    {
        Ray();
    }

    void Ray()
    {
        _ray.direction = new Vector3(0,-0.01f,0);
        _ray = new Ray(transform.position, _ray.direction);
        _hit = new RaycastHit();

        Debug.DrawRay(transform.position, _ray.direction);

        if (Physics.Raycast(_ray,out _hit))
        {
            
            Debug.Log(_hit.collider.gameObject.transform.position.z);
        }
    }
}
