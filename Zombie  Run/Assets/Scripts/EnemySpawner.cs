using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject fastZombiePrefab;
    public GameObject tankZombiePrefab;

    public Vector3 spawnArea = new Vector3(8, 0, 8);

    private float spawnTimer = 0f;
    private float spawnInterval = 3f; // initial interval
    public float minInterval = 1f; // minimum interval as difficulty increases

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Adjust spawn interval based on elapsed time
        float timeElapsed = Time.timeSinceLevelLoad;
        spawnInterval = Mathf.Max(minInterval, 3f - timeElapsed / 60f);
        // Every 60s, interval decreases slowly toward minInterval

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (fastZombiePrefab == null || tankZombiePrefab == null)
        {
            Debug.LogError("Assign enemy prefabs in Inspector!");
            return;
        }

        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            1f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? fastZombiePrefab : tankZombiePrefab;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}