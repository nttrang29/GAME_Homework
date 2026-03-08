using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class EnemyHealth : MonoBehaviour
// {
// public GameObject explosionPrefab;

// private void OnTriggerEnter2D(Collider2D collision) => Die();

// private void Die() => Destroy(gameObject);
// }


public class EnemyHealth : Health
{
    public static int LivingEnemyCount;

    private void Awake() => LivingEnemyCount++;

    protected override void Die()
    {
        LivingEnemyCount--;
        base.Die();
    }
}