using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class KingEnemy : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _health;
        [SerializeField] public float _range;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageCooldown;
        [SerializeField] private GameObject _replacementObjectPrefab;
        private CardLive _card;
    
        private bool _canDamage = true;
    
        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, _range, _layerMask);
    
            if (hit.collider)
            {
                _card = hit.collider.GetComponent<CardLive>();
                Damage();
            }
        }
        private void FixedUpdate()
        {
            if (!_card)
            {
                transform.position -= new Vector3(_speed, 0, 0);
            }
        }
    
        private void Damage()
        {
            if (!_canDamage || !_card) return;
            _canDamage = false;
            Invoke("ResetDamage", _damageCooldown);
            _card.TakeDamage((int)_damage);
        }
    
        private void ResetDamage()
        {
            _canDamage = true;
        }
    
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                SpawnReplacementObject();
                Destroy(gameObject);
            }
        }
    
        private void SpawnReplacementObject()
        {
            if (_replacementObjectPrefab != null)
            {
                GameObject newObject = Instantiate(_replacementObjectPrefab, transform.position, transform.rotation);
            }
            else
            {
                Debug.LogWarning("Replacement object prefab is not assigned.");
            }
        }
    }
}