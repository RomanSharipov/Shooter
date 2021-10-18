using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    public class Params
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Die = "Die";
        public const string BlendTree = "Blend Tree";
    }

    private PlayerInput _playerInput;
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _playerInput.Walked += OnWalk;
        _player.Died += OnDie;
        _player.WasBorn += OnReturnToBlendTree;
    }

    private void OnDisable()
    {
        _playerInput.Walked -= OnWalk;
        _player.Died -= OnDie;
        _player.WasBorn -= OnReturnToBlendTree;
    }

    private void OnWalk(Vector2 direction)
    {
        _animator.SetFloat(Params.Horizontal, direction.x);
        _animator.SetFloat(Params.Vertical , direction.y);
    }

    private void OnDie()
    {
        _animator.Play(Params.Die);
    }

    private void OnReturnToBlendTree()
    {
        _animator.Play(Params.BlendTree);
    }
}
