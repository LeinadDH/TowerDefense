using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(_damage);
                ObjectPooler.EnqueueObject(this, "Shoot");
            }
            if (other.CompareTag("QueenEnemy"))
            {
                other.GetComponent<QueenEnemy>().TakeDamage(_damage);
                ObjectPooler.EnqueueObject(this, "Shoot");
            }
            if (other.CompareTag("KingEnemy"))
            {
                other.GetComponent<KingEnemy>().TakeDamage(_damage);
                ObjectPooler.EnqueueObject(this, "Shoot");
            }
            if (other.CompareTag("Wall"))
            {
                ObjectPooler.EnqueueObject(this, "Shoot");
            }
        }
    }
}