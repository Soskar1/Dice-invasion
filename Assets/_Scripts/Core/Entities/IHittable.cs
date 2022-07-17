using UnityEngine;

namespace Core.Entities
{
    public interface IHittable
    {
        void Hit(int damage);

        LayerMask Layer { get; }
    }
}