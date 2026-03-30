using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    private Health playerHealth;
    private EnemyHealth enemyHealth;

    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public PlayerController playerController;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = this.GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.KnockbackCounter = playerController.KnockbackTotalTime;

            if(collision.transform.position.x < transform.position.x)
            {
                playerController.KnockbackFromRight = true;
            }
            else if (collision.transform.position.x > transform.position.x)
            {
                playerController.KnockbackFromRight = false;
            }
            else if (collision.transform.position.y < transform.position.y)
            {
                playerController.KnockbackFromTop = true;
            }
            else if (collision.transform.position.y > transform.position.y)
            {
                playerController.KnockbackFromTop = false;
            }
            playerHealth.TakeDamage(damage);
        }
        else if(collision.gameObject.tag == "Sword")
        {
            enemyHealth.TakeDamage(5);
        }
    }

    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position -transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) *moveSpeed;
        }
    }
}


