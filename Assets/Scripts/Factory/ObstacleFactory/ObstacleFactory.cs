using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : BaseFactory<ObstaclePrefab>
{
    [SerializeField] internal PlatformFactory _platformPrefab;
    enum Pos { Center};
    void Start()
    {
        PrefabSpawned.Add(FirstPrefab);
    }


    void Update()
    {
        if (Character.localPosition.z > PrefabSpawned[PrefabSpawned.Count - 1].transform.position.z - playerPrefabDistance)
        {
            Spawned();
        } 
            
        
    }

    public override ObstaclePrefab Spawned()
    {
        for (int i = 0; i < 1; i++)
        {
            ObstaclePrefab newObstacle = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
            PrefabSpawned.Add(newObstacle);

            var pos = (Pos)Random.Range(0, 1);

            switch(pos)
            {
                case Pos.Center:
                    //newObstacle.transform.position = _platformPrefab.Center.transform.position;
                    newObstacle.transform.position = _platformPrefab.PrefabSpawned[_platformPrefab.PrefabSpawned.Count - 1].SpawnOne.position;
                return newObstacle;
            }


        }


        return null; 


    }
}
