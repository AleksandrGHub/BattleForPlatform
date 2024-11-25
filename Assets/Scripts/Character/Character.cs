using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Health Health;

    public void TakeDamage(float damage)
    {
        Health.Decrease(damage);
    }
}