using UnityEngine;


public class NewMove : MonoBehaviour
{
    [SerializeField] private float _lineChangeSpeed = 6;
    [SerializeField] private float _lineStep = 0;

    internal Vector3 _targetPos;
    Vector3 _targetSpeed;

    public Rigidbody _rb;
    internal  Animator _animator;

    internal int _line = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _targetPos = transform.position;
    }

    private void Update()
    {
        Move();
        MoveForward();
    }

    private void FixedUpdate()
    {

        CheckPosition();
    }

    public void MoveForward()
    {
        _rb.transform.position += new Vector3(0, 0, 5 * Time.deltaTime);
    }


    void CheckPosition()
    {

        if ((transform.position.x > _targetPos.x && _targetSpeed.x > 0) || (transform.position.x < _targetPos.x && _targetSpeed.x < 0))
        {
            // _targetPos = this.transform.position;
            // _targetSpeed = -_targetSpeed;
            _targetSpeed = Vector3.zero;
             _rb.velocity = _targetSpeed;
             _rb.position = _targetPos; // если убрать = плавное смещение во время прыжка 
        }


    }

    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
             MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }


    }

    private void  MoveRight()
    {


        _targetSpeed = new Vector3(_lineChangeSpeed, 0, 0);
        _targetPos = new Vector3(_targetPos.x + _lineStep, _rb.position.y, _rb.position.z); //0?
        _rb.velocity = _targetSpeed;



        _animator.Play("StrafeRight");




    }

    private void  MoveLeft()
    {

        _targetSpeed = new Vector3(-_lineChangeSpeed, 0, 0);
        _targetPos = new Vector3(_targetPos.x - _lineStep, _rb.position.y, _rb.position.z);
        _rb.velocity = _targetSpeed;



        _animator.Play("StrafeLeft");
 




    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NotLose")
        {
            _rb.velocity = -_targetSpeed ;
        }
    }

}
