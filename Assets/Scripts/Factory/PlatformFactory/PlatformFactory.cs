using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlatformFactory : BaseFactory<PlatformPrefab>
{


    void Start()
    {
        PrefabSpawned.Add(_firstPrefab[0]);
        FirstSpawn();


    }

    void FixedUpdate()
    {

        if (Character.localPosition.z > PrefabSpawned[PrefabSpawned.Count - 1].End.transform.position.z - playerPrefabDistance)
        {

            Spawned();
        }


    }

    void FirstSpawn()
    {
        for(int i =0; i<3; i++)
        {
            //FirstPrefabs.Add(_firstPrefab[0]);
            PlatformPrefab newFirstPlatform = Instantiate(_firstPrefab[Random.Range(0, _firstPrefab.Length)]);

            var previousEndPos = new Vector3(0, 0, PrefabSpawned[PrefabSpawned.Count - 1].End.position.z);

            var endPos = newFirstPlatform.End.position;

            newFirstPlatform.transform.position = previousEndPos + endPos;
            PrefabSpawned.Add(newFirstPlatform);
        }

    }
    public override PlatformPrefab Spawned()
    {
        PlatformPrefab newPlatform = Instantiate(BasePrefabs[Random.Range(0, BasePrefabs.Length)]);
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

