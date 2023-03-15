using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefab : BasePrefab
{
    [SerializeField] internal Transform Begin;
    [SerializeField] internal Transform End;

    [SerializeField] internal Transform SpawnOne;
    [SerializeField] internal Transform SpawnTwo;
    [SerializeField] internal Transform SpawnThree;


    void Update()
    {
        Move();
    }
}
