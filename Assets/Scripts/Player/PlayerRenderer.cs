using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerRenderer : Renderer
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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