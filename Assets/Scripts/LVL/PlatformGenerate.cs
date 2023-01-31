using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    [SerializeField] private Transform Character;
    [SerializeField] private Platform[] PlatformPrefabs;
    [SerializeField] private Platform FirstPlatform;
    [SerializeField] private int platformCount = 8;
    [SerializeField] private float playerPlatromDistance = 45;

    private List<Platform> PlatformSpawned = new List<Platform>();

    public Rigidbody _rb; 

    void Start()
    {
        PlatformSpawned.Add(FirstPlatform);
        Spawned();

        //PlatformSpawned.Add(PlatformPrefabs[0]);
        _rb = GetComponent<Rigidbody>();
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
        var previousEndPos = new Vector3(0, 0, PlatformSpawned[PlatformSpawned.Count - 1].End.position.z);
        var endPos = newPlatform.End.position;

        newPlatform.transform.position = previousEndPos + endPos;

        PlatformSpawned.Add(newPlatform);

        if (PlatformSpawned.Count >= platformCount)
        {
            Destroy(PlatformSpawned[1].gameObject);
            PlatformSpawned.RemoveAt(0);
        }
    }


}
