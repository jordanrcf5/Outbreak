using UnityEngine;
using UnityEngine.InputSystem;

public class MenuPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    float moveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.5f)
        {
            animator.SetFloat("magnitude", rb.linearVelocity.normalized.magnitude);
        }
        else
        {
            animator.SetFloat("magnitude", 0);
        }

        // Read mouse position using new Input System
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Keep same height
        mousePosition.y = transform.position.y;

        Vector2 moveDirection = (mousePosition - transform.position).normalized;

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, 0f);

        spriteRenderer.flipX = moveDirection.x < 0;
    }
}
