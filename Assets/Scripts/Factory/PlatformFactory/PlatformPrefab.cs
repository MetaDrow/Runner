using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformPrefab : BasePrefab
{
    [SerializeField] internal Transform _playerSpawnPosition;
    [SerializeField] internal Transform End;
    public GameObject[] _spawnDots;
    /////////////////////////////////////////////

   // internal List<DynamicObstacle> _obstacles;



    public DynamicObstacle[] _dynamicObstacle;
    public GameObject[] _dynamicDots;



   internal void SpawnDynamicObstacle()
    {
        for (int i = 0; i < _dynamicDots.Length; i++)
        {
  
           // _dynamicObstacle.obstacle obstacles = Instantiate(_dynamicDots[Random.Range(0, _dynamicDots.Length)]);
           DynamicObstacle newObstacleDynamic = Instantiate(_dynamicObstacle[Random.Range(0, _dynamicObstacle.Length)], _playerSpawnPosition);
           newObstacleDynamic.transform.position = _dynamicDots[i].transform.position;


        }

    }


}
