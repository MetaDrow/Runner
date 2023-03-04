using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CharacterMove : AbstractCharacterMove
{
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _targetPos = transform.position;
        _isPlay = true;
    }

    private void Update()
    {
        if (_isPlay)
        {
            Move(ref _line);
            Jump();
        }

    }

    private void FixedUpdate()
    {
        CheckPosition();
        FallJump();
    }

}
