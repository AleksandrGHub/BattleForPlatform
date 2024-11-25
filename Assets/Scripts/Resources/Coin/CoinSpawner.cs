using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private DetectorEnemy _detectorEnemy;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 10;

    private Vector2 _spawnPoint;
    private List<Coin> _coins = new List<Coin>();
    private ObjectPool<Coin> _pool;
    private int _quantityCoin = 3;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (coin) => SetParametersOnGet(coin),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void OnEnable()
    {
        _detectorEnemy.PositionDetected += Spawn;
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            if (coin != null)
            {
                coin.CollisionDetected -= ReleaseObject;
            }
        }

        _detectorEnemy.PositionDetected -= Spawn;
    }
    private IEnumerator Countdown()
    {
        float delay = 0.6f;
        yield return new WaitForSeconds(delay);
        SetActiveCoinsColliderTrue();
    }


    public void Spawn(Vector2 position)
    {
        _spawnPoint = position;

        for (int i = 0; i < _quantityCoin; i++)
        {
            var coin = _pool.Get();

            if (CanAdd(coin) == true)
            {
                _coins.Add(coin);
                coin.CollisionDetected += ReleaseObject;
            }
        }

        StartCoroutine(Countdown());
    }

    private void SetParametersOnGet(Coin coin)
    {
        coin.transform.position = _spawnPoint;
        coin.Init();
        coin.gameObject.SetActive(true);
        coin.Push();
    }

    private void SetActiveCoinsColliderTrue()
    {
        foreach (var coin in _coins)
        {
            coin.SetActiveColliderTrue();
        }
    }

    private void ReleaseObject(Coin coin)
    {
        _pool.Release(coin);
    }

    private bool CanAdd(Coin newCoin)
    {
        bool canAdd = true;

        foreach (var coin in _coins)
        {
            if (coin == newCoin)
            {
                canAdd = false;
            }
        }

        return canAdd;
    }
}