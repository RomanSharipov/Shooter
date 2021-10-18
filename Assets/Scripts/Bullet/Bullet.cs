using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage; 
    [SerializeField] private ParticleSystem _templateCollisionEffect; 

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
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem collisionEffect = Instantiate(_templateCollisionEffect, collision.contacts[0].point, transform.rotation);
        collisionEffect.Play();

        if (collision.gameObject.TryGetComponent(out IDamageable character))
        {
            character.TakeDamage(Damage, collision.contacts[0].point);
        }
        Destroy(gameObject);
    }
}
