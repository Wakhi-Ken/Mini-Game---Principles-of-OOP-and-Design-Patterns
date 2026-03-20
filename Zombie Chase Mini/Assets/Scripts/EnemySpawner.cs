using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject fastZombiePrefab;
    public GameObject tankZombiePrefab;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, 2);

        Vector3 spawnPos = new Vector3(
            Random.Range(-8, 8),
            1,
            Random.Range(-8, 8)
        );

        if (rand == 0)
            Instantiate(fastZombiePrefab, spawnPos, Quaternion.identity);
        else
            Instantiate(tankZombiePrefab, spawnPos, Quaternion.identity);
    }
}