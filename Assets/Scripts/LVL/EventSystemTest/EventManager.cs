using System;
using System.Runtime.InteropServices;
using UnityEngine;

internal class EventManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public static EventManager _instance { get; private set; }

    public static Action onDeathTriggerEnter;
    public static Action onCoinTriggerEnter;
    public static Action onFocus;

    public static bool _death;

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _death = false;
    }

    public void Coin() => onCoinTriggerEnter?.Invoke();
    public void Pause() => onFocus?.Invoke();
    public void Death()
    {
        onDeathTriggerEnter?.Invoke();
        _death = true;
        onDeathTriggerEnter();
    }
}
