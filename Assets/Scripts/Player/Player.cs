using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _startHealth = 100;

    public int Health => _health;
    public event UnityAction Die;
    public event UnityAction Born;
    public event UnityAction<int> HealthChanged;

    public void TakeDamage(int damage)
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
        Die?.Invoke();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerInput>().enabled = false;
    }

    public void SwichOnPlayer()
    {
        Born?.Invoke();
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<PlayerInput>().enabled = true;
        _health = _startHealth;
        HealthChanged?.Invoke(_startHealth);
    }
}