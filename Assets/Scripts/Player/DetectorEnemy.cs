using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemy : MonoBehaviour
{
    private List<Enemy> _enemys = new List<Enemy>();

    public event Action<Vector2> PositionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (HasDetected(enemy) == false)
            {
                _enemys.Add(enemy);
                PositionDetected?.Invoke(enemy.gameObject.transform.position);
            }
        }
    }

    private bool HasDetected(Enemy detectedEnemy)
    {
        bool hasDetected = false;

        foreach (var enemy in _enemys)
        {
            if (enemy == detectedEnemy)
            {
                hasDetected = true;
            }
        }

        return hasDetected;
    }
}