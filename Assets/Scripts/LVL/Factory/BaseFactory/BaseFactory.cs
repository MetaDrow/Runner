using System.Collections.Generic;
using UnityEngine;



public abstract class BaseFactory<T> : MonoBehaviour
{
    [SerializeField] protected T[] _firstPrefab;
    [SerializeField] protected Transform Character;
    [SerializeField] protected T[] BasePrefabs;
    [SerializeField] protected int prefabCount = 8;
    [SerializeField] protected float playerPrefabDistance = 45;
    [SerializeField] internal List<T> PrefabSpawned = new List<T>();
    public abstract T Spawned();
}

