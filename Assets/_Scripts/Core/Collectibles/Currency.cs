using UnityEngine;
using Core.UI;

namespace Core
{
    public class Currency : MonoBehaviour
    {
        [SerializeField] private NumberCounter _counter;
        private int _coins;

        public int Coins 
        { 
            get => _coins; 
            set
            {
                _coins = value;
                _counter.Value = _coins;
            }
        }

        public void AddCoins(int amount)
        {
            _coins += amount;
            _counter.Value = _coins;
        }
    }
}