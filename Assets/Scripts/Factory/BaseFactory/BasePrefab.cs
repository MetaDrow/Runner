using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BasePrefab : MonoBehaviour, IMovePrefab
{

    [SerializeField] public float _speed { set; get; }

    void Start() 
    {
        _speed = 10;
    }
    public void Move()
    {

        transform.position -= new Vector3(0, 0, _speed* Time.deltaTime);
    }


}
