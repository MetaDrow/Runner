
using UnityEngine;


public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] private float lineChangeSpeed = 6;
    [SerializeField] private float lineStep = 0;
    private int line = 0;

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

    private void Update()
    {
        Move(ref line);

    }

    private void FixedUpdate()
    {
        CheckPosition();
    }


    void CheckPosition()
    {

        if ((transform.position.x > targetPos.x && targetSpeed.x > 0) || (transform.position.x < targetPos.x && targetSpeed.x < 0))
        {
            targetSpeed = Vector3.zero;
            _rb.velocity = targetSpeed;
            _rb.position = targetPos;
        }
    }

    private int Move(ref int line)
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            return MoveRight(ref line);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            return MoveLeft(ref line);
        }
        return line;
    }

    private int MoveRight(ref int line)
    {
        switch (line)
        {
            case 0:
                {
                    targetSpeed = new Vector3(lineChangeSpeed, 0, 0);
                    targetPos = new Vector3(targetPos.x + lineStep, _rb.position.y, _rb.position.z); //0?
                    _rb.velocity = targetSpeed;
                    line++;


                    _animator.Play("StrafeRight");
                    return line;
                }
            case -1:
                {
                    targetSpeed = new Vector3(lineChangeSpeed, 0, 0);
                    targetPos = new Vector3(targetPos.x + lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = targetSpeed;

                    line++;


                    _animator.Play("StrafeRight");
                    return line;
                }


        }
        return line;
    }

    private int MoveLeft(ref int line)
    {
        switch (line)
        {
            case 0:
                {
                    targetSpeed = new Vector3(-lineChangeSpeed, 0, 0);
                    targetPos = new Vector3(targetPos.x - lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = targetSpeed;

                    line--;


                    _animator.Play("StrafeLeft");
                    return line;
                }
            case 1:
                {
                    targetSpeed = new Vector3(-lineChangeSpeed, 0, 0);
                    targetPos = new Vector3(targetPos.x - lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = targetSpeed;

                    line--;


                    _animator.Play("StrafeLeft");
                    return line;
                }
        }
        return line;
    }


}
