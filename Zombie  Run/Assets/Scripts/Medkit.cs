using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healAmount = 25f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Heal(healAmount);
            player.medkitsCollected++;
            Destroy(gameObject);
        }
    }
}