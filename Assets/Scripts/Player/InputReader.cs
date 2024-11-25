using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    public const string Jump = nameof(Jump);
    public const string Fire1 = nameof(Fire1);

    private bool _isJump;
    private bool _isAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(Jump))
        {
            _isJump = true;
        }

        if (Input.GetButtonDown(Fire1))
        {
            _isAttack = true;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}