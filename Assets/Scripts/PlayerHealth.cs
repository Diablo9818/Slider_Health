using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    private float _damageCount = 10;
    private float _healCount = 10;

    public event UnityAction<float> OnHealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void Heal()
    {
        if(_currentHealth + _healCount < _maxHealth)
        {
            _currentHealth += _healCount;
        }
        else
        {
            _currentHealth = _maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage()
    {
        if(_currentHealth - _damageCount > 0)
        {
            _currentHealth -= _damageCount;
        }
        else
        {
            _currentHealth = 0;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }
}
