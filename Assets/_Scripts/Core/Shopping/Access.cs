using UnityEngine;
using UnityEngine.UI;

namespace Core.Shopping
{
    public class Access : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private Currency _currency;
        [SerializeField] private Button _buyButton;

        [SerializeField] private int _allowedToBuySameItemCount;

        public int AllowedToBuySameItemCount => _allowedToBuySameItemCount;

        private void OnEnable() => CheckAccess();

        public void CheckAccess()
        {
            if (_shopItem.purchasedTimes >= _allowedToBuySameItemCount)
            {
                _buyButton.interactable = false;
                return;
            }

            if (_currency.Coins < _shopItem.cost)
                _buyButton.interactable = false;
            else
                _buyButton.interactable = true;
        }
    }
}