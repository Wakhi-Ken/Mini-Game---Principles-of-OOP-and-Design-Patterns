using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    // Reference to the medkit prefab to spawn
    public GameObject medkitPrefab;
    public Vector3 spawnArea = new Vector3(8, 0, 8);
    // Timer variables
    private float spawnTimer = 0f;
    private float spawnInterval = 10f; 
    public float minInterval = 3f;   

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Reduce interval over time (every 60 seconds, medkits spawn faster)
        float timeElapsed = Time.timeSinceLevelLoad;
        spawnInterval = Mathf.Max(minInterval, 10f - timeElapsed / 60f * 2f);

        if (spawnTimer >= spawnInterval)
        {
            SpawnMedkit();
            spawnTimer = 0f;
        }
    }

    void SpawnMedkit()
    {
        // Check if the prefab is assigned
        if (medkitPrefab == null)
        {
            Debug.LogError("Assign Medkit prefab in Inspector!");
            return;
        }
        // Generate a random spawn position within the defined area
        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            0.5f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        Instantiate(medkitPrefab, pos, Quaternion.identity);
    }
}