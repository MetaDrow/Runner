using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMove 
{

    void Move(ref int line);


    void MoveRight(ref int line);


    void MoveLeft(ref int line);

}
