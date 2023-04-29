using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager _instance { get; private set; }
    public static Action onDeathTriggerEnter;
    public static Action onCoinTriggerEnter;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

        }
    }

    public void Coin()
    {
        if (onCoinTriggerEnter != null)
        {
            onCoinTriggerEnter();
            Debug.Log("InstanceCoin");
        }
    }

    public void Death()
    {
        if (onDeathTriggerEnter != null)
        {
            onDeathTriggerEnter();
            Debug.Log("InstanceDeath");
        }
    }
}
