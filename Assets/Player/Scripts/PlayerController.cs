using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    Rigidbody2D rb;
    SpriteRenderer spriter;
    Animator anim;

    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveDirection;
    private Vector2 newPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector2(horizontalInput, verticalInput);

        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection.Normalize();
        }

        newPosition = rb.position + (moveSpeed * Time.fixedDeltaTime * moveDirection);

        rb.MovePosition(newPosition);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", moveDirection.magnitude);

        if (horizontalInput != 0)
        {
            spriter.flipX = horizontalInput < 0;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.health -= 10;
        }
    }
}
