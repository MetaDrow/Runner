using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]private float jumpForce = 2f;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            _rb.velocity = Vector3.up * jumpForce;
        }
    }

}
