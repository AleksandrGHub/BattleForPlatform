using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]

public class CharacterRenderer : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void FlipSprite(float direction)
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

    public void SetStateRun(float direction)
    {
        _animator.SetBool(AnimatorController.State.Run, direction != 0);
    }

    public void SetStateJump()
    {
        _animator.SetTrigger(AnimatorController.State.Jump);
    }

    public void SetStateAttack()
    {
        _animator.SetTrigger(AnimatorController.State.Attack);
    }
}