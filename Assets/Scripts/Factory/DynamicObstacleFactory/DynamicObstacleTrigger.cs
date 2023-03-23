using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleTrigger : MonoBehaviour
{
   // public GameObject _DynamicObstacle;
    public Collider _collider;
    public PlatformPrefab _platformPrefab;




    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("DynamicObstacleTrigger") && other.CompareTag("Player"))
        {
            _platformPrefab.SpawnDynamicObstacle();

        }

    }
}
