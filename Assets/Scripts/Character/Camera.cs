using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public Transform _player;
    [SerializeField] private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _player.position;
    }

    void Update()
    {
        transform.position = _player.position + _offset;
    }
}