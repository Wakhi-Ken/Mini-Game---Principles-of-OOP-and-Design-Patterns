using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float health = 50f;

    protected Transform player;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < 1.5f)
        {
            Attack();
        }
        else if (distance < 6f)
        {
            ChasePlayer();
        }
        else
        {
            Idle();
        }
    }

    protected void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void Attack()
    {
        player.GetComponent<PlayerController>().TakeDamage(5f * Time.deltaTime);
    }

    void Idle()
    {
        // do nothing
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}