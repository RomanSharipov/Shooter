using UnityEngine;

public class MoveToPlayerState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Target != null)
        {
            _animator.Play("Run");
            _transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z), _speed * Time.deltaTime);
        }
    }
}
