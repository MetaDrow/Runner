using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CharacterMove : AbstractCharacterMove
{
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _targetPos = _rb.transform.position;
        _isPlay = true;
        // _isJump = false;
        _speed = 10f;
        _isStrafe = false;


    }

    private void Update()
    {

        if (_isPlay)
        {

            Move(ref _line);



        }

    }

    private void FixedUpdate()
    {

        if (_isPlay)
        {
            MoveForward();

            FallJump();
            CheckPosition();

            if (_isStrafe == false)
            {
                Jump();
            }

        }

    }

}
