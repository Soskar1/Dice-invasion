using Core.Weapons;
using UnityEngine;

namespace Core.Entities
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private bool _canShoot = true;
        private bool _timerStarted = false;

        private void OnEnable() => _timerStarted = false;

        private void Update()
        {
            if (!_canShoot)
                return;

            if (_timerStarted)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_weapon.FireRate, () => { _weapon.Fire(); _timerStarted = false; }));
        }

        public void Allow() => _canShoot = true;
        public void Stop() => _canShoot = false;
    }
}