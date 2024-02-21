using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private float _initialDelay = 5f;
        [SerializeField] private float _minSpawnDelay = 15f; 
        [SerializeField] private float _maxSpawnDelay = 30f;

        private bool _isFirstSpawn = true;
        private float _nextSpawnTime;

        void Start()
        {
            _nextSpawnTime = Time.time + _initialDelay;
        }

        void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                SpawnObject();
                _nextSpawnTime = Time.time + Random.Range(_minSpawnDelay, _maxSpawnDelay);
            }
        }

        void SpawnObject()
        {
            float randomXPos = Random.Range(-4.5f, 4.5f);
            Vector2 instancePos = new Vector2(randomXPos, transform.position.y);
            Coin instance = ObjectPooler.DequeueObject<Coin>("Coin");
            instance.gameObject.SetActive(true);
            instance.transform.position = instancePos;

            if (_isFirstSpawn)
            {
                _isFirstSpawn = false;
            }
        }
    }
}