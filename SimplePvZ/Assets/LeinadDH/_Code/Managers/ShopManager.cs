using UnityEngine;
using TMPro;

namespace com.LeinadDH.ChessDefense
{
    public class ShopManager : MonoBehaviour
    {
        public int Coins;
        public GameObject CurrentCard;
        
        [SerializeField] private Sprite _currentCardSprite;
        [SerializeField] private Transform _interactableTiles;
        [SerializeField] private LayerMask _tileLayer;
        [SerializeField] private LayerMask _tileLayerConfirm;
        [SerializeField] private TextMeshProUGUI _coinsText;
        
        private void Update()
        {
            _coinsText.text = Coins.ToString();
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _tileLayer);
            RaycastHit2D compare = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _tileLayerConfirm);
            
            
            foreach (Transform tile in _interactableTiles)
            {
                tile.GetComponent<SpriteRenderer>().enabled = false;
            }
            
            if (hit.collider && CurrentCard && !compare.collider)
            {
                hit.collider.GetComponent<SpriteRenderer>().sprite = _currentCardSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;

                if (Input.GetMouseButton(0))
                {
                    Instantiate(CurrentCard, hit.collider.transform.position, Quaternion.identity);
                    CurrentCard = null;
                    _currentCardSprite = null;
                }
            }
        }

        public void BuyCard(GameObject card, Sprite sprite)
        {
            CurrentCard = card;
            _currentCardSprite = sprite;
        }
    }
}