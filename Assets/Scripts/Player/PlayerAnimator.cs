using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
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
        _playerInput.Walk += Walk;
        _player.Die += Die;
        _player.Born += ReturnToBlendTree;
    }

    private void OnDisable()
    {
        _playerInput.Walk -= Walk;
        _player.Die -= Die;
        _player.Born -= ReturnToBlendTree;
    }

    private void Walk(float horizontal, float vertical)
    {
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
    }

    private void Die()
    {
        _animator.Play("Die");
    }

    private void ReturnToBlendTree()
    {
        _animator.Play("Blend Tree");
    }
}
