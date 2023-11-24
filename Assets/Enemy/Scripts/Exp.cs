using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int exp;
    [SerializeField] private float speed;
    private Transform player;
    private bool moveStart = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (moveStart)
        {
            Vector2 target = new Vector2 (player.position.x, player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, Time.fixedDeltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            moveStart = true;
        }
    }
}
