using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IDamageable
{
    public static event Action<float> OnHealthChanged;

    // Movement variables
    [Header("Movement")]
    public float normalSpeed = 5f;
    public float speedBoost = 10f;
    private bool speedPowerActive = false;
    private int enemyHitsWhilePowered = 0;
    //
    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;
    // Stats
    [Header("Game Stats")]
    public int medkitsCollected = 0;
    // Mouse look variables
    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {

        currentHealth = maxHealth;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        float currentSpeed = speedPowerActive ? speedBoost : normalSpeed;

        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }

    void HandleMouseLook()
    {
        // Get mouse input
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
        // If speed powerup is active, player takes no damage
        currentHealth -= damage;

        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GameManager.instance.GameOver(medkitsCollected, Time.timeSinceLevelLoad);
        }
    }

    public void Heal(float amount)
    {
        // If speed powerup is active, player cannot be healed
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        OnHealthChanged?.Invoke(currentHealth);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void ActivateSpeedPowerup()
    {
        speedPowerActive = true;
        enemyHitsWhilePowered = 0;
    }

    public void EnemyHit()
    {
        // If speed powerup is active, count hits instead of taking damage
        if (speedPowerActive)
        {
            // Each hit while powered counts towards deactivating the powerup
            enemyHitsWhilePowered++;
            if (enemyHitsWhilePowered >= 3)
            {
                speedPowerActive = false;
                enemyHitsWhilePowered = 0;
            }
        }
        else
        {
            TakeDamage(10f);
        }
    }
}