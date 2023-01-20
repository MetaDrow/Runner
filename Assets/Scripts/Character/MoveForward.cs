using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    public float _speed = 0f;
    private bool _startGame;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _startGame = false;
    }


    void FixedUpdate()
    {
        OnAnimatorMove();
    }

    private void OnAnimatorMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) || _startGame == true)
        {
            _startGame = true;
            _animator.SetBool("IsRun", true);
            //_rb.transform.position += Vector3.forward * Time.deltaTime * _speed;
            // transform.position += Vector3.forward * Time.deltaTime * _speed;
            _rb.transform.position += new Vector3(0, 0, 1) * _speed * Time.deltaTime;

        }
    }
}
