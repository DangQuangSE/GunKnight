using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionDame = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDame(explosionDame);
            }
        }
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
