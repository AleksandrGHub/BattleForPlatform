using UnityEngine;

[RequireComponent(typeof(EnemyCombat), typeof(Health), typeof(CoinSpawner))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : Character
{
    public float GetHealth()
    {
        return _health.QuantityHealth;
    }
}