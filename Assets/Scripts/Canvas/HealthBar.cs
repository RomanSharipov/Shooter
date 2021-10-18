using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider _slider;
    [SerializeField]private Player _player;
    [SerializeField]private float _speedDrawing;

    private Coroutine _changeValueJob;

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
    }

    private void OnChangeHealth(int targetHealth)
    {
        if (_changeValueJob != null)
        {
            StopCoroutine(_changeValueJob);
            _changeValueJob = null;
        }
        _changeValueJob = StartCoroutine(ChangeValue(targetHealth));
    }
}
