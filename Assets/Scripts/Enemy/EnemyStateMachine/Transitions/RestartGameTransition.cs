public class RestartGameTransition : Transition
{
    private void Start()
    {
        Target.WasBorn += OnSwitchOnTransition;
    }

    private void OnDisable()
    {
        Target.WasBorn -= OnSwitchOnTransition;
    }
}
