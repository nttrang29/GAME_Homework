using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform playerTarget;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float rotationSpeed = 5f;
    public float fireRate = 1f;
    
    [Header("Giới hạn tầm bắn")]
    public float range = 15f; 
    
    private float fireCountdown = 0f;

    void Update()
    {
        if (playerTarget == null || !playerTarget.gameObject.activeInHierarchy) return;
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
        if (distanceToPlayer <= range)
        {
            Vector3 dir = playerTarget.position - transform.position;
            dir.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
        
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * 20f;
        }
        Destroy(bullet, 2f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}