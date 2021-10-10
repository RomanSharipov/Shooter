using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _speed;

    private Coroutine _moveUpJob;
    private Coroutine _moveDownJob;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private IEnumerator MoveUp()
    {
        while (transform.position != _endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, Time.deltaTime * _speed);
            yield return null;
        }

        if (_moveUpJob != null)
        {
            StopCoroutine(_moveUpJob);
            _moveUpJob = null;
        }
        yield break;
    }

    private IEnumerator MoveDown()
    {
        while (transform.position != _startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, Time.deltaTime * _speed);
            yield return null;
        }

        if (_moveDownJob != null)
        {
            StopCoroutine(_moveDownJob);
            _moveDownJob = null;
        }
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.parent = gameObject.transform;
            _moveUpJob = StartCoroutine(MoveUp());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.parent = null;
            _moveDownJob = StartCoroutine(MoveDown());
        }
    }
}
