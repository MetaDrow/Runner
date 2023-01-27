using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    [SerializeField] private Transform Character; 
    [SerializeField] private Platform[] PlatformPrefabs;
    [SerializeField] private Platform FirstPlatform;
    [SerializeField] private float shearDistance = 5f;
    [SerializeField] private int platformCount = 8;
    [SerializeField] private float playerPlatromDistance = 45;

    private List<Platform> PlatformSpawned = new List<Platform>();

    public Rigidbody _rb; //
   
    void Start()
    {
        PlatformSpawned.Add(FirstPlatform);
        //platformSpawned.Add(PlatformPrefabs[0]);
        _rb= GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Character.localPosition.z > PlatformSpawned[PlatformSpawned.Count - 1].End.transform.position.z - playerPlatromDistance) 
        {
            Spawned();
        }
    }

    private void Spawned()
    {
        Platform newPlatform = Instantiate(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)]);

        Vector3 shearPlatformDistance = new Vector3(0, 0, shearDistance);
        //  newPlatform.transform.position = platformSpawned[platformSpawned.Count -1].End.position; 
        newPlatform.transform.position = PlatformSpawned[PlatformSpawned.Count - 1].End.position + shearPlatformDistance ;

        PlatformSpawned.Add(newPlatform);

        if (PlatformSpawned.Count >= platformCount) 
        {
            Destroy(PlatformSpawned[1].gameObject);
            PlatformSpawned.RemoveAt(1);
            PlatformPrefabsBackPosition();
        }
    }

    private void PlatformPrefabsBackPosition()
    {
        foreach (Platform platform in PlatformPrefabs)
        {
            int platformBackPosition = -30;
            platform.transform.position = new Vector3(0, 0, platformBackPosition);
        }
    }
}

