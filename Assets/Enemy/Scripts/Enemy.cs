using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int HP;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject exp;
    private Transform player;
    private Animator animator;
    private float timeDead = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    { 
        if (animator.GetBool("Dead"))
        {
            timeDead += Time.deltaTime;
            if (timeDead > 0.5f)
            {
                Destroy(rb.gameObject);
            }
        }
        else 
        {
            Vector2 movement = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
    private void Update()
    {
        if (!animator.GetBool("Dead") && player.position.x < rb.position.x)
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
            animator.SetTrigger("Hit");
            FindObjectOfType<AudioManager>().Play("Hit");
            HP -= 1;
        }
        if (HP <= 0)
        {
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
            FindObjectOfType<AudioManager>().Play("Kill");
            animator.SetBool("Dead", true);
            gameObject.tag = "Dead enemy";
            gameObject.GetComponent<Collider2D>().enabled = false;

            Vector2 spawn = new Vector2(rb.position.x, rb.position.y);
            Instantiate(exp, spawn, Quaternion.Euler(0, 0, 0));

        }
    }
}