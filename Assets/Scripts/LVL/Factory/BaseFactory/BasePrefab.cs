using UnityEngine;

public abstract class BasePrefab : MonoBehaviour, IMovePrefab
{
    [SerializeField] public float _speed { set; get; }

    void Start() 
    {
        _speed = 0;
    }
    public void Move()
    {

        transform.position -= new Vector3(0, 0, _speed* Time.deltaTime);
    }
}
