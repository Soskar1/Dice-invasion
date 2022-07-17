using UnityEngine;

namespace Core.Shopping
{
    [CreateAssetMenu(fileName = "ShopItem", menuName = "ScriptableObjects/ShopItem")]
    public class ShopItem : ScriptableObject
    {
        public int cost;
        public int costIncreaseValue;

        public string name;
        public Sprite visual;

        public int purchasedTimes = 0;
    }
}