using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateSpeedPowerup(); // call public method
                Destroy(gameObject);
            }
        }
    }
}