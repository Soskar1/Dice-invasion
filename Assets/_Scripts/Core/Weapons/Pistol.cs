namespace Core.Weapons
{
    public class Pistol : Weapon
    {
        public override void Fire()
        {
            Projectile projectile = _bulletPool.Pool.GetFreeElement();
            projectile.transform.position = _shotPos.position;
            projectile.transform.rotation = _shotPos.rotation;
            projectile.SetWhoIsEnemyLayer(_whoIsEnemy);
            projectile.SetDamage(_damage);

            _soundPlayer.Play();
        }
    }
}