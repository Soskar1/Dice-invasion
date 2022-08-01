using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Core.Shopping
{
    public class ShopItemDisplay : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private Access _access;
        [SerializeField] private Image _visual;

        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _sold;

        [SerializeField] private string _coinEmojiTag = "<sprite=0>";

        private void Awake() => Display();

        private void Display()
        {
            _name.SetText(_shopItem.name);
            RefreshCostText();
            _visual.sprite = _shopItem.visual;
        }

        public void RefreshCostText()
        {
            if (_shopItem.purchasedTimes >= _access.AllowedToBuySameItemCount)
            {
                _costText.gameObject.SetActive(false);
                _sold.gameObject.SetActive(true);
                return;
            }

            _costText.SetText(_coinEmojiTag + _shopItem.cost.ToString());
        }
    }
}