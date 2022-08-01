using UnityEngine;

namespace Core.Shopping
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Currency _currency;

        public void Subtract(ShopItem shopItem)
        {
            _currency.Coins -= shopItem.cost;
            shopItem.cost += shopItem.costIncreaseValue;
            shopItem.purchasedTimes++;
        }
    }
}