using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : BaseFactory<ObstaclePrefab>
{
    [SerializeField] internal PlatformFactory _platformFactory;

    enum Pos { SpawnOne =1, SpawnTwo = 2, SpawnThree = 3 };
    void Start()
    {
        PrefabSpawned.Add(_firstPrefab[0]);
        //PrefabSpawned.Add(FirstPrefab);
    }


    void Update()
    {


        if (Character.localPosition.z > PrefabSpawned[PrefabSpawned.Count - 1].transform.position.z - playerPrefabDistance)
        {
            Spawned();
        }


    }
    private void FixedUpdate()
    {
        ObstacleCheck();
    }

    public override ObstaclePrefab Spawned()
    {


        for (int i =0; i < _platformFactory.PrefabSpawned[_platformFactory.PrefabSpawned.Count - 1]._spawnDots.Length; i++)
        {
            ObstaclePrefab newObstacle = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
            PrefabSpawned.Add(newObstacle);

            newObstacle.transform.position = _platformFactory.PrefabSpawned[_platformFactory.PrefabSpawned.Count - 1]._spawnDots[i].transform.position;
        }


        return null;

    }

    void ObstacleCheck()
    {
        if (PrefabSpawned.Count > prefabCount)
        {
            Destroy(PrefabSpawned[1].gameObject);
            PrefabSpawned.RemoveAt(0);
        }
    }

}
