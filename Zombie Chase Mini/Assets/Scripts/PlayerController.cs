using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHealth = 100f;
    private float currentHealth;

    public int medkitsCollected = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.instance.GameOver(medkitsCollected, Time.timeSinceLevelLoad);
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}