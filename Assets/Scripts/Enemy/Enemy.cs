using UnityEngine;

[RequireComponent(typeof(EnemyCombat), typeof(Health), typeof(EnemyMover))]
[RequireComponent(typeof(EnemyRenderer), typeof(DetectorPlayer))]
public class Enemy : Character
{
    private EnemyRenderer _enemyRenderer;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyRenderer = GetComponent<EnemyRenderer>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _enemyRenderer.Flip(_enemyMover.GetDirection().x);
    }

    public float GetHealth()
    {
        return Health.Quantity;
    }
}