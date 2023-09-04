using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _sliderChangedSpeed;
    private PlayerHealth _playerHealth;
    private Coroutine _coroutine;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _healthSlider.maxValue = _playerHealth.GetCurrentHealth();
        _healthSlider.value = _healthSlider.maxValue;
        _playerHealth.OnHealthChanged += UpdateSlider;
    }
 
    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= UpdateSlider;
    }

    private void UpdateSlider(float newHealth)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(UpdateHealthSlider(newHealth));
    }

    private IEnumerator UpdateHealthSlider(float newHealth)
    {
        while(_healthSlider.value != newHealth)
        {
            float currentSliderValue = _healthSlider.value;
            _healthSlider.value = Mathf.MoveTowards(
                currentSliderValue, 
                newHealth, 
                _sliderChangedSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
