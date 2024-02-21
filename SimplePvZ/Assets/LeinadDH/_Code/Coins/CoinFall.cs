using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class CoinFall : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f; 

        private bool isMoving = false;
        private float moveDuration;

        private void OnDisable()
        {
            isMoving = false;
            moveDuration = Random.Range(3f, 4.5f);
        }

        void Start()
        {
            moveDuration = Random.Range(3f, 4.5f);
        }

        void Update()
        {
            if (transform.position.y >= 5)
            {
                StartMoving();
            }
            
            if (isMoving)
            {
                float moveDistance = moveSpeed * Time.deltaTime;
                transform.Translate(Vector3.down * moveDistance);
                moveDuration -= Time.deltaTime;
                if (moveDuration <= 0)
                {
                    StopMoving();
                }
            }
        }

        void StartMoving()
        {
            isMoving = true;
        }

        void StopMoving()
        {
            isMoving = false;
        }
    }
}