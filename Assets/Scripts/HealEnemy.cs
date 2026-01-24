using UnityEngine;

public class HealEnemy : Enemies
{
    [SerializeField] private float healValue = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(stayDamage);
            }
        }
    }
    public override void Die()
    {
        HealPlayer();
        base.Die(); 
    }
    private void HealPlayer()
    {
        if(player != null)
        {
            player.Heal(healValue);
        }
    }
}
