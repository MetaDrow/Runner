using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject _obstaclePrefab;
    [SerializeField] private float _speed;



    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
    }
}
