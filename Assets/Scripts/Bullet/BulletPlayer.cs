using UnityEngine;

public class BulletPlayer : Bullet
{
    [SerializeField] private ParticleSystem _templateCollisionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem collisionEffect = Instantiate(_templateCollisionEffect, transform.position, transform.rotation);
        collisionEffect.Play();

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage, collision.contacts[0].point);
        }
        Destroy(gameObject);
    }
}
