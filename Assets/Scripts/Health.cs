using UnityEngine;

public class Health : MonoBehaviour
{
    public float QuantityHealth { get; private set; } = 100;

    public void Increase(float health)
    {
        float maxHealth = 100;

        if (QuantityHealth < maxHealth)
        {
            QuantityHealth += health;
        }

        if (QuantityHealth > maxHealth)
        {
            QuantityHealth = maxHealth;
        }
    }

    public void Decrease(float damage)
    {
        float minHealth = 0;

        if (QuantityHealth > minHealth)
        {
            QuantityHealth -= damage;
        }

        if (QuantityHealth < minHealth)
        {
            QuantityHealth = 0;
        }
    }
}