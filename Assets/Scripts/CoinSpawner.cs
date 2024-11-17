using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 10;

    private List<Coin> _coins = new List<Coin>();
    private ObjectPool<Coin> _pool;
    private int _quantityCoin = 3;

    public bool CanSpawn { get; private set; } = true;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => SetParametersOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private IEnumerator Countdown()
    {
        float delay = 0.6f;
        yield return new WaitForSeconds(delay);
        SetActiveCoinsColliderTrue();
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
    }

    public void Spawn()
    {
        GetCoins();
        CanSpawn = false;
        StartCoroutine(Countdown());
    }

    private void SetParametersOnGet(Coin obj)
    {
        obj.transform.position = _spawnPoint.position;
        obj.SetVelocityZero();
        obj.SetActiveColliderFalse();
        obj.gameObject.SetActive(true);
        obj.Push();
    }

    private void GetCoins()
    {
        for (int i = 0; i < _quantityCoin; i++)
        {
            var coin = _pool.Get();
            _coins.Add(coin);
            coin.CollisionDetected += ReleaseObject;
        }
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
}