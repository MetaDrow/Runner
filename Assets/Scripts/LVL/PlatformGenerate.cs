using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    [SerializeField] private Transform Character; // персонажа на -10-15
    [SerializeField] private Platform[] PlatformPrefabs;
    [SerializeField] private Platform FirstPlatform;
    [SerializeField] private float shearDistance = 4.5f;


    private List<Platform> PlatformSpawned = new List<Platform>();
   

    void Start()
    {
        PlatformSpawned.Add(FirstPlatform);
        //platformSpawned.Add(PlatformPrefabs[0]);
    }


    void FixedUpdate()
    {
        if (Character.localPosition.z > PlatformSpawned[PlatformSpawned.Count - 1].End.transform.position.z - 45)
        {
            Spawned();
        }

    }

    private void Spawned()
    {
        Platform newPlatform = Instantiate(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)]);

        Vector3 distance = new Vector3(0, 0, shearDistance);
        //  newPlatform.transform.position = platformSpawned[platformSpawned.Count -1].End.position; // 
        newPlatform.transform.position = PlatformSpawned[PlatformSpawned.Count - 1].End.position + distance;

        PlatformSpawned.Add(newPlatform);


        if (PlatformSpawned.Count >= 8) //8
        {

            Destroy(PlatformSpawned[1].gameObject);//1
            FirstPlatform.transform.position = new Vector3(0, 0, -15);
            PlatformSpawned.RemoveAt(1);
        }
    }
}

