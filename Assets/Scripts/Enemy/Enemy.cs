using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private Player _target;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private ParticleSystem _takeDamageEffect;

    public Player Target => _target; 
    public event UnityAction Died ; 

    public void TakeDamage(int damage,Vector3 collisionPoint)
    {
        ParticleSystem _effectSparks = Instantiate(_takeDamageEffect, collisionPoint, Quaternion.identity);
        _effectSparks.Play();
        _health -= damage;
        if (_health <= 0)
        {
            Died?.Invoke();
            ParticleSystem _effectExplosion = Instantiate(_dieEffect, transform.position, transform.rotation);
            _effectExplosion.Play();
            Destroy(gameObject);
        }
    }
}
