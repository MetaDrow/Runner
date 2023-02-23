using UnityEngine;


public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] private float _lineChangeSpeed = 6;
    [SerializeField] private float _lineStep = 0;

    Vector3 _targetPos;
    Vector3 _targetSpeed;

    private Rigidbody _rb;
    private Animator _animator;

    private int _line = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _targetPos = transform.position;
    }

    private void Update()
    {
        Move(ref _line);
    }

    private void FixedUpdate()
    {
        CheckPosition();
    }

    void CheckPosition()
    {

        if ((transform.position.x > _targetPos.x && _targetSpeed.x > 0) || (transform.position.x < _targetPos.x && _targetSpeed.x < 0))
        {
            _targetSpeed = Vector3.zero;
            _rb.velocity = _targetSpeed;
           // _rb.position = targetPos; // если убрать = плавное смещение во время прыжка 
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
                    _targetSpeed = new Vector3(_lineChangeSpeed, 0, 0);
                    _targetPos = new Vector3(_targetPos.x + _lineStep, _rb.position.y, _rb.position.z); //0?
                    _rb.velocity = _targetSpeed;

                    line++;

                    _animator.Play("StrafeRight");
                    return line;
                }

            case -1:
                {
                    _targetSpeed = new Vector3(_lineChangeSpeed, 0, 0);
                    _targetPos = new Vector3(_targetPos.x + _lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = _targetSpeed;

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
                    _targetSpeed = new Vector3(-_lineChangeSpeed, 0, 0);
                    _targetPos = new Vector3(_targetPos.x - _lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = _targetSpeed;

                    line--;

                    _animator.Play("StrafeLeft");
                    return line;
                }

            case 1:
                {
                    _targetSpeed = new Vector3(-_lineChangeSpeed, 0, 0);
                    _targetPos = new Vector3(_targetPos.x - _lineStep, _rb.position.y, _rb.position.z);
                    _rb.velocity = _targetSpeed;

                    line--;

                    _animator.Play("StrafeLeft");
                    return line;
                }
        }
        return line;
    }
}
