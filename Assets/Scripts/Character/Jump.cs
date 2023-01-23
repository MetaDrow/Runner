using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]private float jumpForce = 2f;
    private bool isGrounded;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            _rb.velocity = (Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

}
