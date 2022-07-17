using UnityEngine;

namespace Core.Collectibles
{
    public class DiceCollectible : Collectible
    {
        [SerializeField] private DiceThrowing _dices;

        public override void Collect() => _dices.AddDice();
    }
}