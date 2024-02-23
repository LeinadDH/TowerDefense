using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class MouseManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _tileLayer;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _tileLayer);
                
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Coin>().OnClick();
                }
            }
        }
    }
}