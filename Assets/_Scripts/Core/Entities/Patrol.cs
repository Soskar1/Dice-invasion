using UnityEngine;

namespace Core.Entities
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private Vector2 _leftPoint;
        [SerializeField] private Vector2 _rightPoint;

        public Vector2 LeftPoint => _leftPoint;
        public Vector2 RightPoint => _rightPoint;

        private void OnDrawGizmosSelected() => Gizmos.DrawLine(_leftPoint, _rightPoint);
    }
}