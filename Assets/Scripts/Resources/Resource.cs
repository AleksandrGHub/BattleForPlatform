using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Resource : MonoBehaviour
{
    protected Collider2D Collider2D;
    protected Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Collider2D = GetComponent<Collider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}