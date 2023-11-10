using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int HP;
    [SerializeField] private int XP;
    [SerializeField] private Rigidbody2D rb;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if (player.position.x < rb.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= 1;
        }
        if (HP <= 0)
        {
            Destroy(rb.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}