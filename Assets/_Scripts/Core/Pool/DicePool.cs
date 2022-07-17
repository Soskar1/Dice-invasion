using UnityEngine;

namespace Core.Pool
{
    public class DicePool : MonoBehaviour
    {
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private Dice _dice;
        [SerializeField] private Transform _container;

        private PoolMono<Dice> _pool;
        public PoolMono<Dice> Pool { get => _pool; }

        public void InitializePool() => _pool = new PoolMono<Dice>(_dice, _poolCount, _autoExpand, _container);
    }
}