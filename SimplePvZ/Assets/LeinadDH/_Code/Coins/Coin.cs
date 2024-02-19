using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class Coin : MonoBehaviour
    {
        private void OnMouseUpAsButton()
        {
            ObjectPooler.EnqueueObject(this, "Coin");
            Debug.Log("Coin Collected");
        }
    }
}