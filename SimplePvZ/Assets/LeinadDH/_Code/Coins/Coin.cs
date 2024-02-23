using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class Coin : MonoBehaviour
    {
        private ShopManager _shopManager;
        
        private void Start()
        {
            _shopManager = GameObject.Find("GameManager").GetComponent<ShopManager>();
        }

        public void OnClick()
        {
            ObjectPooler.EnqueueObject(this, "Coin");
            _shopManager.Coins = _shopManager.Coins + 50;
        }
    }
}