using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private bool hasHit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        PlayerHealthUnitys health = collision.gameObject.GetComponentInParent<PlayerHealthUnitys>();

        if (health != null)
        {
            hasHit = true;
            health.TakeDamage(damage);
            
            Destroy(gameObject); 
        }
        else if (!collision.gameObject.CompareTag("Turret"))
        {
            Destroy(gameObject);
        }
    }
}