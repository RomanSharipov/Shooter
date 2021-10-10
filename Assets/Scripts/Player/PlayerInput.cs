using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public event UnityAction<float,float> Walk;
    public event UnityAction Shoot;

    private float _horizontal;
    private float _vertical;

    private void FixedUpdate()
    {
        _horizontal = _joystick.Horizontal;
        _vertical = _joystick.Vertical;
        Walk?.Invoke(_horizontal, _vertical);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot?.Invoke();
        }
    }
}
