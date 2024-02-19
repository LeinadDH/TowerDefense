using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class SpawnerCoin : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _amplitude = 1f;
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private float _xMovementRange = 0.1f;

        private Vector3 _startPosition;
        private bool _startAnim;
        private float _offset = 0.1f;
        private float _targetX;
        
        private void Start()
        {
            _startPosition = transform.position;
            _startAnim = true;
            _targetX = Random.Range(_startPosition.x - _xMovementRange, _startPosition.x + _xMovementRange);
        }

        private void OnDisable()
        {
            _startAnim = true;
        }

        void Update()
        {
            if (_startPosition.y - _offset > transform.position.y)
            {
                _startAnim = false;
            }

            if (_startAnim)
            {
                float verticalOffset = Mathf.Sin(Time.time * _frequency) * _amplitude;
                float currentX = Mathf.Lerp(transform.position.x, _targetX, Time.deltaTime * _speed);
                Vector3 newPosition = new Vector3(currentX, _startPosition.y + verticalOffset, 0f);
                transform.position = newPosition;
            }
        }
    }
}