using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] ParticleSystem _templateCollisionEffect;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Vector3 collisionPoint = other.ClosestPoint(_transform.position);
            ParticleSystem collisionEffect = Instantiate(_templateCollisionEffect, collisionPoint, transform.rotation);
            collisionEffect.Play();
            player.TakeDamage(_damage, collisionPoint);
        }
    }
}
