using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject fastZombiePrefab;
    public GameObject tankZombiePrefab;

    public GameObject CreateEnemy()
    {
        // Randomly decide which type of enemy to create
        int rand = Random.Range(0, 2);

        if (rand == 0)
            return fastZombiePrefab;
        else
            return tankZombiePrefab;
    }
}