using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : Projectile
    {
        private void Update() => Move();

        public override void Move() => transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}