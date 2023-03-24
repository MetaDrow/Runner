using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentFactory :BaseFactory<EnviromentPrefab>
{
    void Start()
    {
        PrefabSpawned.Add(_firstPrefab[0]);
        //PrefabSpawned.Add(FirstPrefab);
        FirstPlatform();
        Spawned();



    }

    void FixedUpdate()
    {

        if (Character.transform.position.z > PrefabSpawned[PrefabSpawned.Count - 1].transform.position.z - playerPrefabDistance)
        {
            Spawned();
        }


    }

    void FirstPlatform()
    {
        EnviromentPrefab newPlatform = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
        newPlatform.transform.position = Vector3.zero;
        PrefabSpawned.Add(newPlatform);
    }
    public override EnviromentPrefab Spawned()
    {
        EnviromentPrefab newPlatform = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
        var previousEndPos = new Vector3(0, 0, PrefabSpawned[PrefabSpawned.Count - 1].End.position.z);
        var endPos = newPlatform.End.position;

        newPlatform.transform.position = previousEndPos + endPos;

        PrefabSpawned.Add(newPlatform);

        if (PrefabSpawned.Count >= prefabCount)
        {
            Destroy(PrefabSpawned[1].gameObject);
            PrefabSpawned.RemoveAt(0);
        }
        return newPlatform;
    }
}

