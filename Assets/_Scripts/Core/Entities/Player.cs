using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Flipping))]
    public class Player : Entity
    {
        [SerializeField] private Game _game;
        [SerializeField] private Input _input;
        [SerializeField] private Flipping _flipping;
        [SerializeField] private Shooting _shooting;

        private void Update()
        {
            if (_flipping.FacingRight && _input.MovementInput < 0 ||
                !_flipping.FacingRight && _input.MovementInput > 0)
                _flipping.Flip();
        }

        private void FixedUpdate() => Move(_input.MovementInput);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Enemy>() != null)
                Die();
        }

        public override void Move(float direction) => _movement.Move(_input.MovementInput);
        public override void Die()
        {
            _game.GameOver();
            _shooting.Stop();
            _health.ResetHealth();
        }
    }
}