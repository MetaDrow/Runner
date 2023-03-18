using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : BaseFactory<ObstaclePrefab>
{
    [SerializeField] internal PlatformFactory _platformPrefab;
    //[SerializeField] internal PlatformPrefab _platformPrefasb;
    [SerializeField] internal List<Transform> _spawnPoints;
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
        for (int i = 1; i < 4; i++)
        {
            ObstaclePrefab newObstacle = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
            PrefabSpawned.Add(newObstacle);

           // var _spawnRand = _platformPrefasb._spawnPoint[Random.Range(0, 2)];
            // var pos = (Pos)Random.Range(0, 3);
            var pos = (Pos)i;

            switch (pos)
            {
                case Pos.SpawnOne:
                    //newObstacle.transform.position = _platformPrefab.Center.transform.position;
                   newObstacle.transform.position = _platformPrefab.PrefabSpawned[_platformPrefab.PrefabSpawned.Count - 1].SpawnOne.position;
                    //newObstacle.transform.position = _spawnRand.position;
                    break;
                case Pos.SpawnTwo:
                    //newObstacle.transform.position = _platformPrefab.Center.transform.position;
                    newObstacle.transform.position = _platformPrefab.PrefabSpawned[_platformPrefab.PrefabSpawned.Count - 1].SpawnTwo.position;

                    break;
                case Pos.SpawnThree:
                    //newObstacle.transform.position = _platformPrefab.Center.transform.position;
                    newObstacle.transform.position = _platformPrefab.PrefabSpawned[_platformPrefab.PrefabSpawned.Count - 1].SpawnThree.position;

                    break;
            }




        }
        return null;

    }

    void ObstacleCheck()
    {
        if (PrefabSpawned.Count >= prefabCount)
        {
            Destroy(PrefabSpawned[1].gameObject);
            PrefabSpawned.RemoveAt(0);
        }
    }

}
