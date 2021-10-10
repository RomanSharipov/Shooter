using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Start()
    {
        Target.Die += SwitchOnTransition;
    }

    private void OnDisable()
    {
        Target.Die -= SwitchOnTransition;
    }
}
