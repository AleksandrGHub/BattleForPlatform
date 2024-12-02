using System;
using UnityEngine;

public class PlayerCombat : Combat
{
    public event Action<Vector2> PositionDetected;

    private void Attack()
    {
        foreach (var collider in GetColliders2D())
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);

                if (enemy.GetHealth() == 0)
                {
                    PositionDetected?.Invoke(enemy.gameObject.transform.position);
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}