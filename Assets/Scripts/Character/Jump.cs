using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Fall = 2.5f;
    public float LowJump = 2f;
    public float JumpForce = 2f;
    private bool _isGrounded;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /*
    void Update()
    {
        if(_rb.velocity.y < 0 && Input.GetKey(KeyCode.Space))
        {
            _rb.velocity += Vector3.up * JumpForce * Physics.gravity.y;
        }
        else if(_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
        {
            _rb.velocity = Vector3.up * JumpForce * Physics.gravity.y * (LowJump) *  Time.fixedDeltaTime;
        }
    }
    */

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector3.up * JumpForce;
        }
    }

    private void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
