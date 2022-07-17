using UnityEngine;

namespace Core.Entities
{
    [RequireComponent(typeof(Health))]
    public abstract class Entity : MonoBehaviour, IHittable
    {
        [SerializeField] protected Health _health;
        [SerializeField] protected SoundPlayer _hitSoundPlayer;
        protected IMovement _movement;

        public LayerMask Layer => gameObject.layer;

        public virtual void Awake() => _movement = GetComponent<IMovement>();
        public virtual void OnEnable() => _health.Dying += Die;
        public virtual void OnDisable() => _health.Dying -= Die;

        public void Hit(int damage)
        {
            _health.TakeDamage(damage);
            _hitSoundPlayer.Play();
        }

        public abstract void Move(float direction);
        public abstract void Die();
    }
}