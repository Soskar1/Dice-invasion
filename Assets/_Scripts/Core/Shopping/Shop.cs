using UnityEngine;

namespace Core.Shopping
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Currency _currency;

        public void TryBuy(ShopItem shopItem)
        {
            if (_currency.Coins < shopItem.cost)
                return;

            _currency.Coins -= shopItem.cost;
            shopItem.cost += shopItem.costIncreaseValue;
            shopItem.purchasedTimes++;
        }
    }
}