using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    [System.Serializable]
    public class ObjectToSpawn
    {
        public GameObject prefab;
        public int totalSpawnCount;
    }

    public class EnemySpawner : MonoBehaviour
    {
        public ObjectToSpawn[] objectsToSpawn;
        public Transform[] spawnPoints;
        public float totalTimeToSpawn = 720f;
        
        [SerializeField] private GameObject _winPanel;

        private float elapsedTime = 0f;
        private int totalObjectsToSpawn = 0;
        private float spawnInterval = 0f;
        private int currentSpawnIndex = 0;
        private bool startRandomSpawn = false;

        void Start()
        {
            Invoke("StartSpawning", 15f);
            _winPanel.SetActive(false);
        }

        void StartSpawning()
        {
            CalculateSpawnParameters();
        }

        void Update()
        {
            if (elapsedTime < totalTimeToSpawn && currentSpawnIndex < totalObjectsToSpawn)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= spawnInterval && !startRandomSpawn)
                {
                    SpawnObjectAtRandomSpawner();
                    elapsedTime = 0f;
                    currentSpawnIndex++;
                }
                else if (elapsedTime >= 30f && !startRandomSpawn)
                {
                    startRandomSpawn = true;
                }
                else if (startRandomSpawn)
                {
                    SpawnObjectsRandomly();
                    startRandomSpawn = false;
                }
            }
            else
            {
                if (CheckEndGameCondition())
                {
                    _winPanel.SetActive(true);
                }
            }
        }

        bool CheckEndGameCondition()
        {
            foreach (ObjectToSpawn obj in objectsToSpawn)
            {
                if (obj.totalSpawnCount > 0)
                {
                    return false;
                }
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] queenEnemies = GameObject.FindGameObjectsWithTag("QueenEnemy");
            GameObject[] kingEnemies = GameObject.FindGameObjectsWithTag("KingEnemy");
            
            if (enemies.Length > 0)
            {
                return false;
            }
            if (queenEnemies.Length > 0)
            {
                return false;
            }
            if (kingEnemies.Length > 0)
            {
                return false;
            }

            return true;
        }

        void CalculateSpawnParameters()
        {
            foreach (ObjectToSpawn objectToSpawn in objectsToSpawn)
            {
                totalObjectsToSpawn += objectToSpawn.totalSpawnCount;
            }

            spawnInterval = totalTimeToSpawn / totalObjectsToSpawn;
        }

        void SpawnObjectAtRandomSpawner()
        {
            ObjectToSpawn objectToSpawn = ChooseNextObjectToSpawn();
            GameObject prefab = objectToSpawn.prefab;

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Vector3 spawnPosition = spawnPoint.position;
            Quaternion spawnRotation = spawnPoint.rotation;
            Instantiate(prefab, spawnPosition, spawnRotation);
        }

        void SpawnObjectsRandomly()
        {
            for (int i = 0; i < Random.Range(1, 6); i++)
            {
                SpawnObjectAtRandomSpawner();
            }
        }

        ObjectToSpawn ChooseNextObjectToSpawn()
        {
            ObjectToSpawn objectToSpawn = objectsToSpawn[0];
            foreach (ObjectToSpawn obj in objectsToSpawn)
            {
                if (obj.totalSpawnCount > 0)
                {
                    objectToSpawn = obj;
                    obj.totalSpawnCount--;
                    break;
                }
            }

            return objectToSpawn;
        }
    }
}