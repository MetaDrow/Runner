using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPrefab : BasePrefab
{
    [SerializeField] internal Transform _playerSpawnPosition;
    [SerializeField] internal Transform End;
    public GameObject[] _spawnDots;
    /////////////////////////////////////////////

    //public DynamicObstacle _dynamicObstacles;



    public DynamicObstacle[] _dynamicObstacle;
    public GameObject[] _dynamicDots;



   internal void SpawnDynamicObstacle()
    {
        for (int i = 0; i < _dynamicDots.Length; i++)
        {
           // _dynamicObstacle.obstacle obstacles = Instantiate(_dynamicDots[Random.Range(0, _dynamicDots.Length)]);
           DynamicObstacle newObstacleDynamic = Instantiate(_dynamicObstacle[Random.Range(0, _dynamicDots.Length)]);
           newObstacleDynamic.transform.position = _dynamicDots[i].transform.position;
           
        }

    }
}
