using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float normalSpeed = 5f;
    public float speedBoost = 10f;
    private bool speedPowerActive = false;
    private int enemyHitsWhilePowered = 0;

    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Game Stats")]
    public int medkitsCollected = 0;

    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        currentHealth = maxHealth;

        // Hide cursor during gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        float currentSpeed = speedPowerActive ? speedBoost : normalSpeed;
        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        if (playerCamera != null)
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            // Show cursor on Game Over
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GameManager.instance.GameOver(medkitsCollected, Time.timeSinceLevelLoad);
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    // Call when player picks up speed power-up
    public void ActivateSpeedPowerup()
    {
        speedPowerActive = true;
        enemyHitsWhilePowered = 0;
    }

    // Call when player is hit by enemy
    public void EnemyHit()
    {
        if (speedPowerActive)
        {
            enemyHitsWhilePowered++;
            if (enemyHitsWhilePowered >= 3)
            {
                speedPowerActive = false;
                enemyHitsWhilePowered = 0;
            }
        }
        else
        {
            TakeDamage(10f); // normal damage
        }
    }
}