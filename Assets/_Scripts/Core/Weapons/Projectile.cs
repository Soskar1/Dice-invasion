using Core.Entities;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] private float _lifeTime;
        private LayerMask _whoIsEnemy;
        private int _damage;

        private void OnEnable() => StartCoroutine(Timer.Start(_lifeTime, () => gameObject.SetActive(false)));

        public void SetDamage(int damage) => _damage = damage;
        public void SetWhoIsEnemyLayer(LayerMask whoIsEnemy) => _whoIsEnemy = whoIsEnemy;

        public abstract void Move();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHittable entity))
            {
                if ((_whoIsEnemy & 1 << entity.Layer) != 1 << entity.Layer)
                    return;

                entity.Hit(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}