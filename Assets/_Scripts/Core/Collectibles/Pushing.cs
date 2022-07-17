using UnityEngine;

namespace Core.Collectibles
{
    public class Pushing : MonoBehaviour
    {
        [SerializeField] private float _maxPower;
        [SerializeField] private float _minPower;
        [SerializeField] private Rigidbody2D _rb2d;

        private void OnEnable() => Push();

        [ContextMenu("Push")]
        private void Push()
        {
            _rb2d.AddForce(new Vector2(
                Random.Range(-1f, 1f) * TakeRandomPower(),
                Random.Range(0, 1f) * TakeRandomPower()), ForceMode2D.Impulse);
        }

        private float TakeRandomPower() => Random.Range(_minPower, _maxPower);
    }
}