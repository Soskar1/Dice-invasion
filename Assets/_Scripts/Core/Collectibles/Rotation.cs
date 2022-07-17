using UnityEngine;

namespace Core.Collectibles
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _time;
        private float _timer;

        private void OnEnable() => _timer = _time;

        private void Update()
        {
            if (_timer <= 0)
                return;

            transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
            _timer -= Time.deltaTime;
        }
    }
}