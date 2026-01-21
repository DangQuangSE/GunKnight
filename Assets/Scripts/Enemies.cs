using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected PlayerMovement player;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
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
}