using UnityEngine;

public abstract class AttackState : State
{
    [SerializeField] private float _delay;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    public virtual void LookAtPlayer(Player target)
    {
        if (target != null)
        {
            _transform.LookAt(new Vector3(target.transform.position.x, _transform.position.y, target.transform.position.z));
        }
    }

    public abstract void Attack(Player player);
}
