using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed = 2f;
    protected Transform player;
    private Rigidbody rb;

    protected virtual void Start()
    {
        // Find the player in the scene by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        // Move towards the player
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 move = direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collided with the player
        if (collision.collider.CompareTag("Player"))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(10f);
            }

            Destroy(gameObject);
        }
    }
}