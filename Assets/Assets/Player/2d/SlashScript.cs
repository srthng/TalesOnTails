using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D ColliderSlash;
    [SerializeField] private int damage = 10;
    public float knockbackForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Spider"))
        {
            Debug.Log("Enemy hit! Applying damage.");
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                enemy.TakeDamage(damage, knockbackDirection);
            }
        }
    }
}
