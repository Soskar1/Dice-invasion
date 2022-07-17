using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PointsDisplay : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _points;
        [SerializeField] private SpriteRenderer _renderer;

        public void Display(int points) => _renderer.sprite = _points[points - 1];
    }
}