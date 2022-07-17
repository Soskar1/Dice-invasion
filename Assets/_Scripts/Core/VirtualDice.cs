using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Core
{
    [Serializable]
    public class VirtualDice
    {
        [SerializeField] private int _sides;

        public int Roll() => Random.Range(1, _sides + 1);
    }
}