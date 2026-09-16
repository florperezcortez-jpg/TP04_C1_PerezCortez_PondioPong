using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool obstaclePool;
    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] private float spawnRadius = 2f;

    private float timer;

    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.MatchOver)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(randomOffset.x, randomOffset.y, 0f);

        GameObject obj = obstaclePool.Get(spawnPos, Quaternion.identity);

        PooledObject pooled = obj.GetComponent<PooledObject>();
        pooled.SetPool(obstaclePool);
    }
}