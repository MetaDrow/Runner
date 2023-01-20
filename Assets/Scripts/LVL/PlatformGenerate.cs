using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public Transform Character;
    public Platform[] PlatformPrefabs;
    public Platform FirstPlatform;

    private List<Platform> platformSpawned = new List<Platform>();

    void Start()
    {
        platformSpawned.Add(FirstPlatform);
    }


    void Update()
    {
        if(Character.localPosition.z > platformSpawned[platformSpawned.Count -1].End.transform.position.z - 50)
        {
            Spawned();
        }
        
    }

    private void Spawned()
    {
        Platform newPlatform = Instantiate(PlatformPrefabs[Random.Range(0,PlatformPrefabs.Length)]);
        newPlatform.transform.position = platformSpawned[platformSpawned.Count -1].End.position; //сдвигаем точку end в редакторе, подумать! 
        platformSpawned.Add(newPlatform);
  

        if(platformSpawned.Count >= 8 ) 
        {
            Destroy(platformSpawned[1].gameObject);
            platformSpawned.RemoveAt(0);
        }
    }
}
