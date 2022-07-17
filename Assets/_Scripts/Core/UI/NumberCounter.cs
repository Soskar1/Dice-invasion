using UnityEngine;
using TMPro;
using System;
using System.Collections;

namespace Core.UI
{
    public class NumberCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _duration;

        private int _fps;
        private Coroutine _countingCoroutine;

        private int _value;

        public int Value 
        { 
            get => _value; 
            set
            {
                UpdateText(value);
                _value = value;
            } 
        }

        private void UpdateText(int newValue)
        {
            if (_countingCoroutine != null)
                StopCoroutine(_countingCoroutine);

            _countingCoroutine = StartCoroutine(CountText(newValue));
        }

        private IEnumerator CountText(int newValue)
        {
            WaitForSeconds Wait = new WaitForSeconds(1f / _fps);
            int previousValue = _value;
            int stepAmount;

            if (newValue - previousValue < 0)
                stepAmount = Mathf.FloorToInt((newValue - previousValue) / (_fps * _duration));
            else
                stepAmount = Mathf.CeilToInt((newValue - previousValue) / (_fps * _duration));

            if (previousValue < newValue)
            {
                while(previousValue < newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue > newValue)
                        previousValue = newValue;

                    _text.SetText(previousValue.ToString());

                    yield return Wait;
                }
            }
            else
            {
                while (previousValue > newValue)
                {
                    previousValue += stepAmount;

                    if (previousValue < newValue)
                        previousValue = newValue;

                    _text.SetText(previousValue.ToString());

                    yield return Wait;
                }
            }
        }

        public void Initialize(int fpsLock) => _fps = fpsLock;
    }
}