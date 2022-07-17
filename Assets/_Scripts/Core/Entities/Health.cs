using System;
using UnityEngine;

namespace Core.Entities
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        public Action<int> OnCurrentHealthChanged;
        public Action Dying;

        public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
                Die();

            OnCurrentHealthChanged?.Invoke(_currentHealth);
        }

        public void IncreaseMaxHealth()
        {
            _maxHealth++;
            ResetHealth();
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
            OnCurrentHealthChanged?.Invoke(_currentHealth);
        }

        private void Die() => Dying?.Invoke();
    }
}