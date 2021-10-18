using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public event UnityAction<Vector2> Walked;
    public event UnityAction Shot;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        Walked?.Invoke(_direction);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot?.Invoke();
        }
    }
}
