using UnityEngine;

public class Renderer : MonoBehaviour
{
    public void Flip(float direction)
    {
        Vector2 rotate = transform.eulerAngles;

        if (direction > 0)
        {
            rotate.y = 0;
        }

        if (direction < 0)
        {
            rotate.y = 180;
        }

        transform.rotation = Quaternion.Euler(rotate);
    }
}