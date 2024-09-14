using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out AidKit aidKit))
        {
            _player.IncreaceHealth(aidKit.Health);
            Destroy(collision.gameObject);
        }
    }
}
