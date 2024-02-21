using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.LeinadDH.ChessDefense
{
    public class CardsSlot : MonoBehaviour
    {
        [SerializeField] private Sprite _cardSprite;
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private int _cardCost;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _costText; 
        private ShopManager _shopManager;

        private void Start()
        {
            _shopManager = GameObject.Find("GameManager").GetComponent<ShopManager>();
        }

        public void BuyCard()
        {
            if (_shopManager.Coins >= _cardCost && !_shopManager.CurrentCard)
            {
                _shopManager.Coins -= _cardCost;
                _shopManager.BuyCard(_cardPrefab, _cardSprite);
            }
        }
        
        private void OnValidate()
        {
            if (_cardSprite != null)
            {
                _icon.enabled = true;
                _icon.sprite = _cardSprite;
                _costText.text = _cardCost.ToString();
            }
            else
            {
                _icon.enabled = false;
                _costText.text = "";
            }
        }
    }
}