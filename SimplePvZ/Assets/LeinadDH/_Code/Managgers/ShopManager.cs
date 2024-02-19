using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject _currentCard;
        [SerializeField] private Sprite _currentCardSprite;
        [SerializeField] private Transform _interactableTiles;
        [SerializeField] private LayerMask _tileLayer;
        
        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _tileLayer);

            foreach (Transform tile in _interactableTiles)
            {
                tile.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (hit.collider && _currentCard)
            {
                hit.collider.GetComponent<SpriteRenderer>().sprite = _currentCardSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (Input.GetMouseButton(0) && _currentCard)
            {
                Instantiate(_currentCard, hit.collider.transform.position, Quaternion.identity);
                _currentCard = null;
                _currentCardSprite = null;
            }
        }

        public void BuyCard(GameObject card, Sprite sprite)
        {
            _currentCard = card;
            _currentCardSprite = sprite;
        }
    }
}