using System;
using UnityEngine;

public class Coin : Resource
{
    public event Action<Coin> CollisionDetected;

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
        Rigidbody2D.AddForce(new Vector2(coordinateX, coordinateY));
    }

    public void ActivateCollider()
    {
        Collider2D.enabled = true;
    }

    public void DeactivateCollider()
    {
        Collider2D.enabled = false;
    }

    public void ResetVelocity()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }
}