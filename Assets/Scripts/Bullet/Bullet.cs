using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage; 

    protected float Speed => _speed;
    protected int Damage => _damage;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = transform.forward * _speed * Time.deltaTime ;
        _rigidbody.velocity = _direction;
    }

    private void OnEnable()
    {
        Destroy(gameObject, 5);
    }
}
