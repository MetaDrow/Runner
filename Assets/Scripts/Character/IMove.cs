using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMove 
{
    [SerializeField] float _speed { set; get; }


    void MoveForward();

    void MoveRight(ref int line);


    void MoveLeft( ref int line);

}
