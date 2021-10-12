using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _template;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Shot += Shoot;
    }

    private void OnDisable()
    {
        _playerInput.Shot -= Shoot;
    }

    private void Shoot()
    {
        var bullet = Instantiate(_template, _shootPoint.position, _shootPoint.rotation);
    }
}
