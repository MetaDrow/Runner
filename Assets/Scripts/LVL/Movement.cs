using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float _speed = 5f;

    public int _leftStep = 0;
    public int _rightStep = 0;
    private int _line = 0;


    public float laneOffset = 15;
    public float laneChangeSpeed = 15;

    Vector3 targetPos;
    Vector3 targetSpeed;

    private Rigidbody _rb;
    private Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        targetPos = transform.position;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckPosition();
        Move(ref _line);


    }

    void CheckPosition()
    {
        _rb.velocity = targetSpeed;
        if ((transform.position.x > targetPos.x && targetSpeed.x > 0) || (transform.position.x < targetPos.x && targetSpeed.x < 0))
        {
            targetSpeed = Vector3.zero;
            _rb.velocity = targetSpeed;
            _rb.position = targetPos;
        }
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
        if (_line == 0)
        {

            // _rb.velocity = new Vector3(targetPos.x + _rightStep, 0, 0);
            targetSpeed = new Vector3(6, 0, 0);
            targetPos = new Vector3(targetPos.x + _rightStep, targetPos.y, targetPos.z); // 0 y 0z

            _line++;
            _animator.Play("StrafeRight");
            return _line;
        }

        if (_line == -1)
        {
            targetSpeed = new Vector3(6, 0, 0);
            targetPos = new Vector3(targetPos.x + _rightStep, targetPos.y, targetPos.z);

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
            targetSpeed = new Vector3(-6, 0, 0);
            targetPos = new Vector3(targetPos.x + _leftStep, targetPos.y, targetPos.z);


            //_rb.velocity = new Vector3(targetPos.x + _leftStep, 0, 0);


            _line--;
            _animator.Play("StrafeLeft");
            return _line;
        }


        if (_line == -2)
        {
            targetSpeed = new Vector3(-6, 0, 0);
            targetPos = new Vector3(targetPos.x + _leftStep, targetPos.y, targetPos.z);

            // _rb.velocity = new Vector3(targetPos.x + _leftStep, 0, 0);

            _line++;
            _animator.Play("StrafeLeft");
            return _line;
        }


        return _line;

    }

}