using UnityEngine;

public class PlatformPrefab : BasePrefab
{
    [SerializeField] internal Transform _playerSpawnPosition;
    [SerializeField] internal Transform End;
    public GameObject[] _spawnDots;

    /////////////////////////////////////////////

    public DynamicObstacle[] _dynamicObstacle;
    public GameObject[] _dynamicDots;

    internal void SpawnDynamicObstacle()
    {
        for (int i = 0; i < _dynamicObstacle.Length; i++)
        {
            DynamicObstacle newObstacleDynamic = Instantiate(_dynamicObstacle[Random.Range(0, _dynamicObstacle.Length)], _playerSpawnPosition);
            var pos = Random.Range(0, _dynamicDots.Length);

            newObstacleDynamic.transform.position = _dynamicDots[pos].transform.position;
        }
    }

}
