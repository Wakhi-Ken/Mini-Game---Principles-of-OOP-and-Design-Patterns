using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    protected Transform player;
    private Rigidbody rb;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate() // use FixedUpdate for physics
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 move = direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController playerCtrl = collision.collider.GetComponent<PlayerController>();
            if (playerCtrl != null)
            {
                playerCtrl.TakeDamage(10f);
            }

            Destroy(gameObject); // destroy only this enemy
        }
    }
}