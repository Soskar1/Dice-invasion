using UnityEngine;

namespace Core
{
    public class IncreasingDifficulty : MonoBehaviour
    {
        [SerializeField] private float _timeAcceleration;
        private const float DEFAULT_TIME = 1;

        [SerializeField] private float _delay;
        private float _timer;

        private void OnEnable() => _timer = _delay;

        private void Update()
        {
            if (_timer <= 0)
            {
                Time.timeScale += _timeAcceleration;
                _timer = _delay;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        public void SetDefaultTime() => Time.timeScale = DEFAULT_TIME;
    }
}