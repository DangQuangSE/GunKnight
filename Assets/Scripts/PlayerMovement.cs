using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ChangeDirection(playerInput);
        ChangeAnimation(playerInput);
    }
    private void FixedUpdate()
    {
        PlayerMove();
        
    }
    private void PlayerMove()
    {
        rb.linearVelocity = playerInput.normalized * moveSpeed;
    }
    private void ChangeDirection(Vector2 input)
    {
        if (input.x < 0)
            spriteRenderer.flipX = true;
        else if (input.x > 0)
            spriteRenderer.flipX = false;
    }
    private void ChangeAnimation(Vector2 input)
    {
        if (input != Vector2.zero)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
