using Core.Collectibles;
using UnityEngine;

namespace Core.Pool
{
    public class DiceCollectiblePool : MonoBehaviour
    {
        [SerializeField] private int _poolCount;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private DiceCollectible _dice;
        [SerializeField] private Transform _container;

        private PoolMono<DiceCollectible> _pool;
        public PoolMono<DiceCollectible> Pool { get => _pool; }

        public void InitializePool() => _pool = new PoolMono<DiceCollectible>(_dice, _poolCount, _autoExpand, _container);
    }
}