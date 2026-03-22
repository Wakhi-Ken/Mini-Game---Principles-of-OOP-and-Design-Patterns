using UnityEngine;

public class Medkit : MonoBehaviour
{
    // Amount of health the medkit restores
    public float healAmount = 25f;

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Heal(healAmount);
            player.medkitsCollected++;
            Destroy(gameObject);
        }
    }
}