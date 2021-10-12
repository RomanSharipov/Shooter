using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Start()
    {
        Target.Died += OnSwitchOnTransition;
    }

    private void OnDisable()
    {
        Target.Died -= OnSwitchOnTransition;
    }
}
