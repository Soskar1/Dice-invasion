using Core.Entities;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health _player;
        [SerializeField] private TextMeshProUGUI _healthText;

        private void OnEnable() => _player.OnCurrentHealthChanged += RefreshText;
        private void OnDisable() => _player.OnCurrentHealthChanged -= RefreshText;

        private void RefreshText(int currentHealth) => _healthText.SetText(currentHealth.ToString());
    }
}