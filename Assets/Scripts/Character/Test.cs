using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    CharacterController controller;
    Vector3 startGamePosition;
    Vector3 targetPos;
   public  float laneOffset = 2.5f;
   public  float laneChangeSpeed = 15;
    Vector3 targetVelocity;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();
        startGamePosition = transform.position;
        targetPos = transform.position;
    }


    void Update()
    {



        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset) // одно нажатие клавиши
        {


            targetVelocity = new Vector3(laneChangeSpeed, 0, 0);
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
            _animator.Play("StrafeRight");
        }

        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > -laneOffset) // одно нажатие клавиши
        {

            targetVelocity = new Vector3(-laneChangeSpeed, 0, 0);
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);

            _animator.Play("StrafeLeft");
        }

        //Move();

        //target = transform.position + Vector3.right;
        // transform.position = Vector3.MoveTowards(transform.position, target, 0.05f);

    }
    void Move()
    {


    }
    private void FixedUpdate()
    {

        _rb.velocity = targetVelocity;
        if ((transform.position.x > targetPos.x && targetVelocity.x > 0) ||
          (transform.position.x < targetPos.x && targetVelocity.x < 0))
        {
            targetVelocity = Vector3.zero;
            _rb.velocity = targetVelocity;
            _rb.position = targetPos;
        }
    }
}
