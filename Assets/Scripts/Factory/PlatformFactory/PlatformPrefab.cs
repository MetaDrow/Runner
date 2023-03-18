using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefab : BasePrefab
{
    [SerializeField] internal Transform _playerSpawnPosition;
    [SerializeField] internal Transform End;


    public GameObject[] _spawnDots; 

    void Update()
    {
        Move();
    }
}
