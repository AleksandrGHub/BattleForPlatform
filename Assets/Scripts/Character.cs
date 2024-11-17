using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Health _health;

    public void TakeDamage(float damage)
    {
        _health.Decrease(damage);
    }
}