using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private Vector3 _direction;
    private Vector3 _position;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.Walked += OnWalk;
    }

    private void OnDisable()
    {
        _playerInput.Walked -= OnWalk;
    }

    private void OnWalk(Vector2 direction)
    {
        _direction = transform.right * direction.x + transform.forward * direction.y;
        _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y;
    }
}
