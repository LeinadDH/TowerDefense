 using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class SlotMachine : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _spawnInterval;
        
        private Animator _animator;
        private float _spawnTimer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;
            
            if (_spawnTimer >= _spawnInterval)
            {
                _animator.SetTrigger("OnSpawnCoin");
                _spawnTimer = 0f;
            }
        }

        public void SpawnCoin()
        {
            Coin instance = ObjectPooler.DequeueObject<Coin>("Coin");
            instance.gameObject.SetActive(true);
            instance.transform.position = _spawnPoint.position;
        }

        public void EndSpawnAnimation()
        {
            _animator.ResetTrigger("OnSpawnCoin");
        }
    }
}