using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
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
        float minCoordinateX = -90f;
        float maxCoordinateX = 90f;
        float coordinateY = 260f;
        coordinateX = UnityEngine.Random.Range(minCoordinateX, maxCoordinateX);
        _rigidbody2D.AddForce(new Vector2(coordinateX, coordinateY));

    }

    public void SetActiveColliderTrue()
    {
        _collider2D.enabled = true;
    }

    public void SetActiveColliderFalse()
    {
        _collider2D.enabled = false;
    }

    public void SetVelocityZero()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}