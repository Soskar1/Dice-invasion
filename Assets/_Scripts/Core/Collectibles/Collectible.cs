using Core.Entities;
using UnityEngine;
using Core.Pool;

namespace Core.Collectibles
{
    public abstract class Collectible : MonoBehaviour
    {
        [SerializeField] private TemporaryObjectPool _tempPool;

        public abstract void Collect();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                Collect();
                _tempPool.Pool.HasFreeElement(out var temp);
                gameObject.SetActive(false);
            }
        }
    }
}