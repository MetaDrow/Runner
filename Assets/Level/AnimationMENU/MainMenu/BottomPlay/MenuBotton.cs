using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuBotton : MonoBehaviour
{
    public UnityEvent _unityEvent;
    public GameObject _botton;
    public Animator _animator;
    void Start()
    {
        _botton = this.gameObject;
    }

    public void OnMouseUpAsButton()
    {
        _animator.SetBool("DownAnim",true);
        _unityEvent.Invoke();
    }
    public void OnMouseOver()
    {
        _animator.SetBool("UpAnim", true);
    }
    public void OnMouseExit()
    {
        _animator.SetBool("UpAnim", false);
    }
}
