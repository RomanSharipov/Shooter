using UnityEngine;

public class BulletEnemy : Bullet
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
