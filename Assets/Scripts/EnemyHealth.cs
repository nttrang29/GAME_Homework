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
protected override void Die()
{
base.Die();
Debug.Log("Enemy died");
}
}