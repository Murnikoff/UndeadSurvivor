using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    //public static int damage;
    public LayerMask whatIsSolid;


    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        
        //if (hitInfo.collider != null)
        //{
          //  if (hitInfo.collider.CompareTag("Enemy"))
            //{
              //  hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            //}
            //Destroy(gameObject);
        //}
        transform.Translate(translation: speed * Time.fixedDeltaTime * Vector2.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
