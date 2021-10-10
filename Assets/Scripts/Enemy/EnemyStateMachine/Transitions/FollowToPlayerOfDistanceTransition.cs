using UnityEngine;

public class FollowToPlayerOfDistanceTransition : Transition
{
    [SerializeField] private int _distanceToPlayer;

    private void Update()
    {
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < _distanceToPlayer)
            {
                SwitchOnTransition();
            }
        }
    }
}
