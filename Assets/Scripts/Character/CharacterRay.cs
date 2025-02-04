using UnityEngine;

public class CharacterRay : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    public Transform _pointer;
    void Ray()
    {
        _ray.direction = new Vector3(0,-0.01f,0);
        _ray = new Ray(transform.position, _ray.direction);
        _hit = new RaycastHit();

        Debug.DrawRay(transform.position, _ray.direction);

        if (Physics.Raycast(_ray,out _hit))
        {
            Debug.Log(_hit.collider.gameObject.transform.position.z);
        }
    }
}
