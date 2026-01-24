using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] private Image hpBar;
    protected float currentHP;
    private void Start()
    {
        currentHP = maxHp;
        UpdateHPBar();
    }
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
    public void TakeDame(float damage)
    {
        currentHP -= damage;
        UpdateHPBar();
        currentHP = Mathf.Max(currentHP, 0);
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void UpdateHPBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHp;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void Heal(float healValue)
    {
        if (currentHP < maxHp)
        {
            Debug.Log("Healing Player" + healValue);
            currentHP += healValue;
            currentHP = Mathf.Min(currentHP, maxHp);
            UpdateHPBar();
        }
    }
}
