using UnityEngine;

public class CelebrationState : State
{
    private void OnEnable()
    {
        _animator.Play("Victory");
    }
}
