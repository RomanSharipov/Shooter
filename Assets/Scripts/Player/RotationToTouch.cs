using UnityEngine;

public class RotationToTouch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _distanceToPoint;
    [SerializeField] private Transform _transform;

    private Ray _rayMouse;
    private Vector3  _pointOnRay;
    private RaycastHit _hit;

    private void LateUpdate() 
    {
        _rayMouse = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_rayMouse, out _hit))
            _transform.LookAt(_hit.point);
        else
        {
            _pointOnRay = _rayMouse.GetPoint(_distanceToPoint);
            _transform.LookAt(_pointOnRay);
        }
    }
}

