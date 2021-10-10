using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider _slider;
    [SerializeField]private Player _player;
    [SerializeField]private float _speedDrawing;

    private Coroutine _changeValueCoroutine;

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeHealth;
    }

    private IEnumerator ChangeValue(int targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, Time.deltaTime * _speedDrawing);
            yield return null;
        }
        if (_changeValueCoroutine != null)
        {
            StopCoroutine(_changeValueCoroutine);
            _changeValueCoroutine = null;
        }
        yield break;
    }

    private void OnChangeHealth(int targetHealth)
    {
        if (_changeValueCoroutine != null)
        {
            StopCoroutine(_changeValueCoroutine);
            _changeValueCoroutine = null;
        }
        _changeValueCoroutine = StartCoroutine(ChangeValue(targetHealth));
    }
}
