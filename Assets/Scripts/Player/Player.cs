using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(InputReader), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerRenderer), typeof(PlayerCombat), typeof(Health))]
[RequireComponent(typeof(Picker))]
public class Player : Character
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private PlayerMover _mover;
    private PlayerRenderer _characterRenderer;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _characterRenderer = GetComponent<PlayerRenderer>();
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

    private void Update()
    {
        _characterRenderer.Flip(_inputReader.Direction);
        _characterRenderer.SetStateRun(_inputReader.Direction);
    }
}