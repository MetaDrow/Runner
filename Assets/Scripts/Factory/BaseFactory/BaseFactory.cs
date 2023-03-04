using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BaseFactory<T> : MonoBehaviour
{
    [SerializeField] protected T FirstPrefab;
    [SerializeField] protected Transform Character;
    [SerializeField] protected T[] BasePrefabs;
    [SerializeField] protected int prefabCount = 8;
    [SerializeField] protected float playerPrefabDistance = 45;
    internal List<T> PrefabSpawned = new List<T>();


    public abstract T Spawned();



}

