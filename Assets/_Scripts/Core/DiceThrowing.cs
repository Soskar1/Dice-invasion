using Core.Pool;
using UnityEngine;
using System.Linq;
using TMPro;

namespace Core
{
    public class DiceThrowing : MonoBehaviour
    {
        [Header("Currency")]
        [SerializeField] private Currency _currency;

        [Header("Spawning")]
        [SerializeField] private DicePool _pool;
        [SerializeField] private Transform _spawnPoint;

        [Header("Throw All Dices offer")]
        [SerializeField] private GameObject _throwAllDicesOffer;
        [SerializeField] private TextMeshProUGUI _diceCountText;

        [Header("Start UI")]
        [SerializeField] private GameObject _startButton;

        private int _d6;

        private const float DURATION_DELAY = 1.5f;
        private float _duration;

        private bool _throwingStarted = false;

        private void Update()
        {
            if (!_throwingStarted)
                return;

            if (_duration <= 0)
            {
                _currency.AddCoins(GetResult());
                _pool.Pool.DeactivateAllElements();

                _startButton.SetActive(true);

                _throwingStarted = false;
            }
            else
            {
                _duration -= Time.deltaTime;
            }
        }

        public void AddDice()
        {
            _d6++;
            _diceCountText.SetText(_d6.ToString());
        }

        public void TryOfferDiceThrowing()
        {
            if (_d6 == 0)
                return;

            _throwAllDicesOffer.SetActive(true);
        }
        
        //Button
        public void ThrowAllDices()
        {
            while (_d6 > 0)
            {
                Throw();
                _d6--;
            }

            _diceCountText.SetText(_d6.ToString());
            _throwAllDicesOffer.SetActive(false);
        }

        private void Throw()
        {
            _pool.Pool.HasFreeElement(out Dice dice);
            dice.transform.position = _spawnPoint.position;

            if (!_throwingStarted)
            {
                _duration = dice.GetDuration() + DURATION_DELAY;
                _throwingStarted = true;
            }
        }

        private int GetResult()
        {
            var dices = _pool.Pool.GetAllActiveElements();
            return dices.Select(x => x.Result).Sum();
        }
    }
}