using Core.Collectibles;
using Core.Pool;
using UnityEngine;

namespace Core.Entities
{
    public class Reward : MonoBehaviour
    {
        [SerializeField] private Collectible _collectible;
        [SerializeField] private DiceCollectiblePool _pool;

        public void Drop()
        {
            _pool.Pool.HasFreeElement(out var dice);
            dice.transform.position = transform.position;
        }
    }
}