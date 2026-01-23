using UnityEngine;

public class EnergyEnemy : Enemies
{
    [SerializeField] private GameObject energyEffect;
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
        if(energyEffect != null)
        {
            GameObject energy = Instantiate(energyEffect, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }
        base.Die();
    } 
}
