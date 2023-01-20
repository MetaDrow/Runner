using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float _speed = 5f;

    public int _leftStep = 0;
    public int _rightStep = 0;
    private int _line = 0;


    private Transform _player;
    private Rigidbody _rb;
    private Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move(ref _line);
    }

    //возможно не нужен 
    private void MoveForward()
    {
        Vector3 move = new Vector3(0, 0, 1);
        _rb.velocity = move * _speed;
    }

    private int Move(ref int _line)
    {

        if (Input.GetKeyDown(KeyCode.D))
        {

            return MoveRight(ref _line);

        }

        if (Input.GetKeyDown(KeyCode.A)) //&& _line == 0) //|| _line == 1)
        {

            return MoveLeft(ref _line);

        }
        return _line;
    }

    private int MoveRight(ref int _line)
    {

        if (_line == -1)
        {

            _rb.velocity = new Vector3(_rightStep, 0, 0);
            _line++;
            _animator.Play("StrafeRight");
            return _line;

        }

        if (_line == 0)
        {
            _rb.velocity = new Vector3(_rightStep, 0, 0);
            _line++;
            _animator.Play("StrafeRight");
            return _line;
        }


        if (_line == 2)
        {
            _line--;
            return _line;
        }

        return _line;
    }

    private int MoveLeft(ref int _line)
    {


        if (_line == 0 || _line == 1)
        {
            _rb.velocity = new Vector3(_leftStep, 0, 0);
            _line--;
            _animator.Play("StrafeLeft");
            return _line;
        }


        if (_line == -2)
        {
            _rb.velocity = new Vector3(_leftStep, 0, 0);
            _line++;
            _animator.Play("StrafeLeft");
            return _line;
        }


        return _line;

    }

}
