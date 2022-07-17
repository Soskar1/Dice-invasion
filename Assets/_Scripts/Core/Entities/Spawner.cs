using UnityEngine;
using System.Collections.Generic;
using Core.Pool;

namespace Core.Entities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _pool;
        [SerializeField] private float _spawnRate;
        private float _timer;

        [SerializeField] private Transform _spawnPoint;

        private void OnEnable() => _timer = _spawnRate;

        private void Update()
        {
            if (_timer <= 0)
            {
                Spawn();
                _timer = _spawnRate;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        private void Spawn()
        {
            _pool.Pool.HasFreeElement(out Enemy enemy);
            enemy.transform.position = _spawnPoint.position;
        }
    }
}