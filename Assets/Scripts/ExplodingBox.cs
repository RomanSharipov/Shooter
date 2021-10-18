using UnityEngine;

public class ExplodingBox : MonoBehaviour
{
    [SerializeField] private ParticleSystem _templateExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bulletPlayer))
        {
            ParticleSystem explosion = Instantiate(_templateExplosion, transform.position, transform.rotation);
            explosion.Play();
            Destroy(gameObject);
        }
    }
}
