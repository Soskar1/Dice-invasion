using UnityEngine;

namespace Core.Entities
{
    public class Enemy : Entity
    {
        [SerializeField] private PointsDisplay _pointsDisplay;
        [SerializeField] private Patrol _patrol;
        [Range(-1,1)][SerializeField] private int _moveDirection = 1;
        [SerializeField] private VirtualDice _startHealth;
        [SerializeField] private Reward _reward;

        private int _defaultMoveDirection;

        private Transform _transform;

        public override void Awake()
        {
            base.Awake();
            _transform = transform;
            _defaultMoveDirection = _moveDirection;
        }

        public override void OnEnable()
        {
            base.OnEnable();

            _health.OnCurrentHealthChanged += _pointsDisplay.Display;
            _health.Dying += _reward.Drop;

            _health.CurrentHealth = _startHealth.Roll();
            _pointsDisplay.Display(_health.CurrentHealth);
        }

        public override void OnDisable()
        {
            base.OnDisable();

            _health.OnCurrentHealthChanged -= _pointsDisplay.Display;
            _health.Dying -= _reward.Drop;

            _moveDirection = _defaultMoveDirection;
        }

        private void Update()
        {
            if (_transform.position.x > _patrol.RightPoint.x && _moveDirection == 1 ||
                _transform.position.x < _patrol.LeftPoint.x && _moveDirection == -1)
            {
                _moveDirection *= -1;
                _transform.position = new Vector2(_transform.position.x, _transform.position.y - 1f);
            }

            Move(_moveDirection);
        }

        public override void Move(float direction) => _movement.Move(direction);
        public override void Die() => gameObject.SetActive(false);
    }
}