using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    public GameObject medkitPrefab;
    public float spawnInterval = 5f;
    public Vector3 spawnArea = new Vector3(8, 0, 8);

    void Start()
    {
        InvokeRepeating("SpawnMedkit", 2f, spawnInterval);
    }

    void SpawnMedkit()
    {
        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            0.5f,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        Instantiate(medkitPrefab, pos, Quaternion.identity);
    }
}