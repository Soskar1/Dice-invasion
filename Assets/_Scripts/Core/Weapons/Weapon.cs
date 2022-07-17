using Core.Pool;
using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected BulletPool _bulletPool;
        [SerializeField] protected Transform _shotPos;
        [SerializeField] protected LayerMask _whoIsEnemy;
        [SerializeField] protected SoundPlayer _soundPlayer;
        [SerializeField] protected int _damage;
        [SerializeField] private float _fireRate;

        public float FireRate => _fireRate;

        public abstract void Fire();

        public void IncreaseDamage() => _damage++;
        public void IncreaseFireRate(float amount) => _fireRate -= amount;
    }
}