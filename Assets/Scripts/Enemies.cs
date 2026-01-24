using UnityEngine;
using UnityEngine.UI;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    [SerializeField] protected float maxHp = 50f;
    [SerializeField] private Image hpBar;
    protected float currentHP;
    protected Player player;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHP = maxHp;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        MoveEnemyToPlayer();
    }
    protected void MoveEnemyToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }

    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }
    public virtual void TakeDame(float shootDame)
    {
        UpdateHpBar();
        currentHP -= shootDame;
        currentHP = Mathf.Max(currentHP, 0);
        if(currentHP <= 0)
        {
            Die();
        }   
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHp;
        }
    }
}