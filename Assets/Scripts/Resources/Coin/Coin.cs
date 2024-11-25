using System;
using UnityEngine;

public class Coin : Resource
{
    public event Action<Coin> CollisionDetected;

    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Release()
    {
        CollisionDetected?.Invoke(this);
    }

    public void Push()
    {
        float coordinateX;
        float minCoordinateX = -70f;
        float maxCoordinateX = 70f;
        float coordinateY = 220f;
        coordinateX = UnityEngine.Random.Range(minCoordinateX, maxCoordinateX);
        _rigidbody2D.AddForce(new Vector2(coordinateX, coordinateY));

    }

    public void SetActiveColliderTrue()
    {
        _collider2D.enabled = true;
    }

    public void Init()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _collider2D.enabled = false;
    }
}