using Core.Collectibles;
using Core.Entities;
using Core.Pool;
using Core.UI;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private DiceCollectiblePool _diceCollectiblePool;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private DicePool _dicePool;
        [SerializeField] private TemporaryObjectPool _tempPool;

        [Header("Core")]
        [SerializeField] private Spawner _spawner;
        [SerializeField] private DiceThrowing _diceThrowing;
        [SerializeField] private IncreasingDifficulty _increaseDifficulty;
        [SerializeField] private Music _music;

        [Header("UI")]
        [SerializeField] private NumberCounter _counter;
        [SerializeField] private GameObject _shopButton;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _currencyUI;

        [Header("Global Settings")]
        [SerializeField] private int _fpsLock;

        private void Awake()
        {
            _bulletPool.InitializePool();
            _diceCollectiblePool.InitializePool();
            _enemyPool.InitializePool();
            _dicePool.InitializePool();
            _tempPool.InitializePool();

            _counter.Initialize(_fpsLock);

            //Invisible Wall & Enemy
            Physics2D.IgnoreLayerCollision(3, 6);

            //Dice & Player;
            Physics2D.IgnoreLayerCollision(7, 8);

            //Dice & Dice
            Physics2D.IgnoreLayerCollision(8, 8);

            Application.targetFrameRate = _fpsLock;
        }

        public void StartGame()
        {
            _spawner.enabled = true;
            _increaseDifficulty.enabled = true;

            _music.PlayBattleMusic();
        }

        public void GameOver()
        {
            _spawner.enabled = false;
            _increaseDifficulty.enabled = false;

            _startButton.SetActive(true);
            _currencyUI.SetActive(true);
            _shopButton.SetActive(true);

            _bulletPool.Pool.DeactivateAllElements();
            _enemyPool.Pool.DeactivateAllElements();
            _diceCollectiblePool.Pool.DeactivateAllElements();

            _diceThrowing.TryOfferDiceThrowing();
            _increaseDifficulty.SetDefaultTime();
            _music.PlayHubMusic();
        }
    }
}