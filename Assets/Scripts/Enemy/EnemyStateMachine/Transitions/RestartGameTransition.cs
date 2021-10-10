public class RestartGameTransition : Transition
{
    private void Start()
    {
        Target.Born += SwitchOnTransition;
    }

    private void OnDisable()
    {
        Target.Born -= SwitchOnTransition;
    }
}
