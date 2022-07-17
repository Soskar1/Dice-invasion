using UnityEngine;

namespace Core.Collectibles
{
    public class Bouncing : MonoBehaviour
    {
        [SerializeField] private float _dropSpeed = 10f;
        [SerializeField] private Rigidbody2D _rb2d;
        private Vector2 _lastVelocity;

        private void FixedUpdate() => _lastVelocity = _rb2d.velocity;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var speed = _lastVelocity.magnitude / _dropSpeed;
            var direction = Vector2.Reflect(_lastVelocity.normalized,
                                            collision.contacts[0].normal);

            _rb2d.velocity = direction * speed;
        }
    }
}