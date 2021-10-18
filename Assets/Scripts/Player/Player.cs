using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    private int _startHealth = 100;
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    public int Health => _health;
    public event UnityAction Died;
    public event UnityAction WasBorn;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    public void TakeDamage(int damage,Vector3 collisionPoint)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            SwichOffPlayer();
        }
    }

    public void SwichOffPlayer()
    {
        Died?.Invoke();
        _boxCollider.enabled = false;
        _rigidbody.isKinematic = true;
        _playerInput.enabled = false;
    }

    public void SwichOnPlayer()
    {
        WasBorn?.Invoke();
        _boxCollider.enabled = true;
        _rigidbody.isKinematic = false;
        _playerInput.enabled = true;
        _health = _startHealth;
        HealthChanged?.Invoke(_startHealth);
    }
}