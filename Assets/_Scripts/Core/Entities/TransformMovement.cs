using UnityEngine;

namespace Core.Entities
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _speed;
        private Transform _transform;

        private void Awake() => _transform = transform;

        public void Move(float direction) => _transform.Translate(Vector2.right * direction * _speed * Time.deltaTime);
    }
}