using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace com.LeinadDH.ChessDefense
{
    public class ShopManager : MonoBehaviour
    {
        public int Coins;
        public GameObject CurrentCard;
        
        [SerializeField] private Sprite _currentCardSprite;
        [SerializeField] private Transform _interactableTiles;
        [SerializeField] private LayerMask _tileLayer;
        [SerializeField] private TextMeshProUGUI _coinsText;
        
        private void Update()
        {
            _coinsText.text = Coins.ToString();
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _tileLayer);

            foreach (Transform tile in _interactableTiles)
            {
                tile.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (hit.collider && CurrentCard)
            {
                hit.collider.GetComponent<SpriteRenderer>().sprite = _currentCardSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;

                if (Input.GetMouseButton(0) && hit.collider.GetComponent<Tile>().HasPlant == false)
                {
                    Instantiate(CurrentCard, hit.collider.transform.position, Quaternion.identity);
                    hit.collider.GetComponent<Tile>().HasPlant = true;
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