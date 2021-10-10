using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] ParticleSystem _templateCollisionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            ParticleSystem collisionEffect = Instantiate(_templateCollisionEffect, transform.position, transform.rotation);
            collisionEffect.Play();
            player.TakeDamage(_damage);
        }
    }
}
