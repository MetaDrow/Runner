using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f;
    public float gravityScale = 0;
    private Rigidbody _rb;
    Animator _anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _anim.Play("RunningJump");
            _rb.velocity = Vector3.up * jumpForce;
        }


        if (_rb.position.y > 1) //out of if 
        {
            Vector3 gravity = new Vector3(0, -gravityScale, 0);
            _rb.velocity = gravity;
        }
    }
}
