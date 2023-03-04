using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlatformFactory : BaseFactory<PlatformPrefab>
{

    void Start()
    {
        PrefabSpawned.Add(FirstPrefab);
        Spawned();

        //PlatformSpawned.Add(PlatformPrefabs[0]);

    }

    void FixedUpdate()
    {

        if (Character.localPosition.z > PrefabSpawned[PrefabSpawned.Count - 1].End.transform.position.z - playerPrefabDistance)
        {
            Spawned();
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

