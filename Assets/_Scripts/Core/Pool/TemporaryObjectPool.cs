using UnityEngine;

namespace Core.Pool
{
    public class TemporaryObjectPool : MonoBehaviour
    {
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private TemporaryObject _temp;
        [SerializeField] private Transform _container;

        private PoolMono<TemporaryObject> _pool;
        public PoolMono<TemporaryObject> Pool { get => _pool; }

        public void InitializePool() => _pool = new PoolMono<TemporaryObject>(_temp, _poolCount, _autoExpand, _container);
    }
}