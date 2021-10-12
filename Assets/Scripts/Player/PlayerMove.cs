using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour
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
        _playerInput.Walked += Walk;
    }

    private void OnDisable()
    {
        _playerInput.Walked -= Walk;
    }

    private void Walk(float horizontal, float vertical)
    {
        _direction = transform.right * horizontal + transform.forward * vertical;
        _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y;
    }
}
