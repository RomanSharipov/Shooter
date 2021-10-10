using UnityEngine;

public class AttackTransition : Transition
{
    [SerializeField] private int _distanceToPlayer;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _distanceToPlayer)
        {
            SwitchOnTransition();
        }
    }
}
