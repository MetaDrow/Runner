using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f;
    public float gravityScale = 0;
    private Rigidbody _rb;
    Animator _anim;
    private bool _isGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _anim.Play("RunningJump");
            _rb.velocity = Vector3.up * jumpForce;
            _isGround= false;
        }

        
        if (_rb.position.y > 1 ) //out of if 
        {

            _anim.Play("Fall");

        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _anim.Play("Roll");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGround = true;
    }
}
