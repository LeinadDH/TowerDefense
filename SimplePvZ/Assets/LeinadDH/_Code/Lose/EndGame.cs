using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject _endGamePanel;

        private void Start()
        {
            _endGamePanel.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _endGamePanel.SetActive(true);
            }
            if (other.CompareTag("QueenEnemy"))
            {
                _endGamePanel.SetActive(true);
            }
            if (other.CompareTag("KingEnemy"))
            {
                _endGamePanel.SetActive(true);
            }
        }
    }

}