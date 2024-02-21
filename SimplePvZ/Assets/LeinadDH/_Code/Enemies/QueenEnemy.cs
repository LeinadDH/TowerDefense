using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class QueenEnemy : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _health;
        [SerializeField] public float _range;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageCooldown;
        private CardLive _card;
        private bool _canDamage = true;
        private bool _moveUp = false;

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
                // Movimiento diagonal en un ángulo de 45 grados hacia abajo y a la izquierda
                Vector3 movement = new Vector3(-_speed, (_moveUp ? _speed : -_speed), 0) * Time.fixedDeltaTime;
                transform.position += movement;
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
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                _moveUp = !_moveUp; // Cambiar la dirección del movimiento en el eje y
            }
        }
    }
}