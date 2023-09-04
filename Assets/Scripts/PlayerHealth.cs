using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event UnityAction<float> OnHealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void Heal(float healCount)
    {
        _currentHealth += healCount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(float damageCount)
    {
        _currentHealth -= damageCount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }
}
