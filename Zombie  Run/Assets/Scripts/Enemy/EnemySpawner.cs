using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Reference to the EnemyFactory to create enemies
    public EnemyFactory factory;

    public Vector3 spawnArea = new Vector3(8, 0, 8);

    private float spawnTimer = 0f;
    private float spawnInterval = 3f;
    public float minInterval = 1f;

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;
        // Decrease spawn interval over time to increase difficulty
        float timeElapsed = Time.timeSinceLevelLoad;
        spawnInterval = Mathf.Max(minInterval, 3f - timeElapsed / 60f);

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (factory == null)
        {

            Debug.LogError("Assign EnemyFactory in Inspector!");
            return;
        }

        // Generate a random spawn position within the defined area

        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            1f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        GameObject enemyPrefab = factory.CreateEnemy();
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}