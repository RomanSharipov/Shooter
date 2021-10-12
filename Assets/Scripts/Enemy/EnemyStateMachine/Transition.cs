using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected bool _needTransit;
    protected Player Target { get; private set; }
    protected Enemy Enemy { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit => _needTransit;

    private void OnEnable()
    {
        _needTransit = false;
        Enemy = GetComponent<Enemy>();
    }

    protected void OnSwitchOnTransition()
    {
        _needTransit = true;
    }

    public void Init(Player target)
    {
        Target = target;
    }
}
