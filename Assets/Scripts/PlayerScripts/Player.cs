using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(InputReader), typeof(CharacterMover))]
[RequireComponent(typeof(CharacterRenderer), typeof(CharacterCombat))]

public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private CharacterMover _mover;
    private CharacterRenderer _characterRenderer;

    public float Health { get; private set; } = 100;
    public float Damage { get; private set; } = 40;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<CharacterMover>();
        _characterRenderer = GetComponent<CharacterRenderer>();
    }

    private void Update()
    {
        _characterRenderer.FlipSprite(_inputReader.Direction);
        _characterRenderer.SetStateRun(_inputReader.Direction);
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _characterRenderer.SetStateJump();
        }

        if (_inputReader.GetIsAttack())
        {
            _characterRenderer.SetStateAttack();
        }
    }

    public void IncreaceHealth(float health)
    {
        float maxHealth = 100;

        if (Health < maxHealth)
        {
            Health += health;
        }

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        float minHealth = 0;

        if (Health > minHealth)
        {
            Health -= damage;
        }

        if (Health < minHealth)
        {
            Health = 0;
        }
    }
}