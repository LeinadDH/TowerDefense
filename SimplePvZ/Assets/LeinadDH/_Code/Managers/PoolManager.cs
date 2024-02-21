using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Shoot _shootPrefab;

        private void Awake()
        {
            SetupPool();
        }

        private void SetupPool()
        {
            ObjectPooler.SetupPool(_coinPrefab, 25, "Coin");
            ObjectPooler.SetupPool(_shootPrefab, 50, "Shoot");
        }
    }

}