using UnityEngine;
using System.Collections;

namespace Core
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private int _rollCount;
        [SerializeField] private float _rollDifference;
        [SerializeField] private PointsDisplay _display;

        [SerializeField] private ColorPicker _colorPicker;
        [SerializeField] private TrailRenderer _trail;

        private int _result;

        public int Result => _result;

        private void OnEnable()
        {
            _trail.startColor = _colorPicker.PickRandomColorFromList();
            StartCoroutine(Roll());
        }

        private IEnumerator Roll()
        {
            int randomDiceSide = 0;

            for (int index = 0; index < _rollCount; index++)
            {
                randomDiceSide = Random.Range(1, 7);
                _display.Display(randomDiceSide);

                yield return new WaitForSeconds(_rollDifference);
            }

            _result = randomDiceSide;
        }

        public float GetDuration() => _rollDifference * _rollCount;
    }
}