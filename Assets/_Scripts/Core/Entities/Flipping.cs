using UnityEngine;

namespace Core.Entities
{
    public class Flipping : MonoBehaviour
    {
        [SerializeField] private bool _facingRight = true;
        public bool FacingRight => _facingRight;

        public void Flip()
        {
            _facingRight = !_facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}