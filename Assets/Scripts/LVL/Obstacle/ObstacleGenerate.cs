using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class ObstacleGenerate : MonoBehaviour
{
    public Obstacle[] obstacle;
    public Obstacle firstObstacle;
    public PlatformGenerate _generator;
    public Platform _platform;

    [SerializeField] private Transform Character;
    [SerializeField] private float playerObstacleDistance = 45;
    public int obstacleCount;

    [SerializeField] private List<Obstacle> obstacleSpawn = new List<Obstacle>();
    enum Pos { Left, Center, Right, LeftRight };

    void Start()
    {
        obstacleSpawn.Add(firstObstacle);
    }


    void FixedUpdate()
    {
        if (Character.localPosition.z > obstacleSpawn[obstacleSpawn.Count - 1].transform.position.z - playerObstacleDistance)
        {
            Spawned();
        }
    }

    void Spawned()
    {

        for (int i = 0; i < 1; i++)
        {
            Obstacle newObstacle = Instantiate(obstacle[Random.Range(0, obstacle.Length)]);
            obstacleSpawn.Add(newObstacle);
            var pos = (Pos)Random.Range(0, 3);
            switch (pos)
            {

                case Pos.Left:
                    if (obstacleSpawn[obstacleSpawn.Count - 1].transform.position != _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnLeft.position)
                    {
                        newObstacle.transform.position = _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnLeft.position;

                    }
                    break;

                case Pos.Right:
                    if(obstacleSpawn[obstacleSpawn.Count - 1].transform.position != _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnRight.position)
                    {
                        newObstacle.transform.position = _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnRight.position;

                    }
                    break;

                case Pos.Center:
                    if (obstacleSpawn[obstacleSpawn.Count - 1].transform.position != _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnCenter.position)
                    {
                        newObstacle.transform.position = _generator.PlatformSpawned[_generator.PlatformSpawned.Count - 1].spawnCenter.position;

                    }

                    break;

            }
        }





        // newSpawn.transform.position = this._platform.spawnCenter.localPosition;
    }
}

