using Core.Entities;
using UnityEngine;

namespace Core.Pool
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform _container;

        private PoolMono<Enemy> _pool;
        public PoolMono<Enemy> Pool { get => _pool; }

        public void InitializePool() => _pool = new PoolMono<Enemy>(_enemy, _poolCount, _autoExpand, _container);
    }
}