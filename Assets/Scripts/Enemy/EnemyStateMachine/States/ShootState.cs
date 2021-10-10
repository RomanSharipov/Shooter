using UnityEngine;

public class ShootState : AttackState
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _template;

    public override void Attack(Player target)
    {
        LookAtPlayer(target);
        _animator.Play("Idle");
        var bullet = Instantiate(_template, _shootPoint.position, _shootPoint.rotation);
    }
}
