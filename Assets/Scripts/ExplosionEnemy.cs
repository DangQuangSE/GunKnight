using UnityEngine;

public class ExplosionEnemy : Enemies
{
    [SerializeField] private GameObject explosionEffect;

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
        Explode();
        base.Die();
    }
    private void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
    }
}
