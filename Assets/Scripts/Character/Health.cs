using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxQuantity = 100;
    private float _minQuantity = 0;

    public float Quantity { get; private set; }

    private void Awake()
    {
        Quantity = _maxQuantity;
    }

    public void Increase(float health)
    {

        if (Quantity < _maxQuantity)
        {
            Quantity += health;
        }

        if (Quantity > _maxQuantity)
        {
            Quantity = _maxQuantity;
        }
    }

    public void Decrease(float damage)
    {

        if (Quantity > _minQuantity)
        {
            Quantity -= damage;
        }

        if (Quantity < _minQuantity)
        {
            Quantity = _minQuantity;
        }
    }
}