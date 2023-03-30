using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovePrefab
{
    //need get
    [SerializeField] float _speed { set; get; }
    void Move();
}
