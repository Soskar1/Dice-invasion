using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ColorPicker : MonoBehaviour
    {
        [SerializeField] private List<Color> _colors;

        public Color PickRandomColorFromList() => _colors[Random.Range(0, _colors.Count)];
    }
}