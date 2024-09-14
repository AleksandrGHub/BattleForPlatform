using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private int _quantityCoin = 3;

    public void Spawn()
    {
        Coin coin;
        float coordinateX;
        float coordinateY;
        float _minCoordinateX = -110f;
        float _maxCoordinateX = 110f;
        float _minCoordinateY = 100f;
        float _maxCoordinateY = 250f;

        for (int i = 0; i < _quantityCoin; i++)
        {
            coin = Instantiate(_prefab, transform.position, Quaternion.identity);
            coordinateX = Random.Range(_minCoordinateX, _maxCoordinateX);
            coordinateY = Random.Range(_minCoordinateY, _maxCoordinateY);
            coin.Push(coordinateX, coordinateY);
        }
    }
}