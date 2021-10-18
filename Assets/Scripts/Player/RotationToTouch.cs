using UnityEngine;

public class RotationToTouch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _distanceToPoint;
    [SerializeField] private Transform _transform;

    private Ray _rayMouse;
    private Vector3  _pointOnRay;

    private void LateUpdate() 
    {
        _rayMouse = _camera.ScreenPointToRay(Input.mousePosition);
        _pointOnRay = _rayMouse.GetPoint(_distanceToPoint);
        _transform.LookAt(_pointOnRay);
    }
}

