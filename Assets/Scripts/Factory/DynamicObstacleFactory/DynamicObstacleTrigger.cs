using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleTrigger : MonoBehaviour
{
    public GameObject _DynamicObstacle;
    public Collider _collider;
    public PlatformPrefab _platformPrefab;
    void Start()
    {
        _DynamicObstacle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // OnTrigeredObstacle( _collider);
    }

    public void OnTrigeredObstacle(Collider _collider)
    {
        if (CompareTag("DynamicObstacleTrigger") && _collider.CompareTag("Player"))
        {
            _DynamicObstacle.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("DynamicObstacleTrigger") && other.CompareTag("Player"))
        {
            _platformPrefab.SpawnDynamicObstacle();

        }

    }
}
