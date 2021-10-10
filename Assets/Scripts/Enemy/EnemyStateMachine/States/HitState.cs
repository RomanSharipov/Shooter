public class HitState : AttackState
{
    public override void Attack(Player target)
    {
        LookAtPlayer(target);
        _animator.Play("Attack", 0, 0);
    }
}
