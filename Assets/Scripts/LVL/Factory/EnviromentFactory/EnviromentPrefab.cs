using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentPrefab : BasePrefab
{
    [SerializeField] internal Transform Begin;
    [SerializeField] internal Transform End;
    void Update()
    {
        Move();
    }
}
