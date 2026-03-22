using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Reference to the powerup prefab to spawn
    public GameObject powerupPrefab;
    public float spawnInterval = 20f;
    public Vector3 spawnArea = new Vector3(8, 0, 8);

    void Start()
    {
        // Start spawning powerups at regular intervals
        InvokeRepeating("SpawnPowerup", 10f, spawnInterval);
    }

    void SpawnPowerup()
    {
        // Check if the prefab is assigned
        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            0.5f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        Instantiate(powerupPrefab, pos, Quaternion.identity);
    }
}