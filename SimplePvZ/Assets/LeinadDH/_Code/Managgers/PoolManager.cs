using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;

        private void Awake()
        {
            SetupPool();
        }

        private void SetupPool()
        {
            ObjectPooler.SetupPool(_coinPrefab, 25, "Coin");
        }
    }

}