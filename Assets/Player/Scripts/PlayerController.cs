using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveDirection;
    private Vector2 newPosition;

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
}
