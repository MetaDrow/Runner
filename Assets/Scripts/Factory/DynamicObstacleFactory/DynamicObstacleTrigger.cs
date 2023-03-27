using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleTrigger : MonoBehaviour
{
   // public GameObject _DynamicObstacle;
    public Collider _collider;
    public PlatformPrefab _platformPrefab;

    int count = 0;


    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("DynamicObstacleTrigger") && other.CompareTag("Player") && count ==0)
        {
            count++;
            _platformPrefab.SpawnDynamicObstacle();
            

        }

    }
}
