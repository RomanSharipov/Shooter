using UnityEngine;

public class TakeDamageTransition : Transition
{
    [SerializeField] private int _maxDistance;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bulletPlayer))
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < _maxDistance)
            {
                OnSwitchOnTransition();
            }
        }
    }
}
