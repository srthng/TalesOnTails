using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float stunnedDuration = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    public Animator anim;
    public GameObject VisionRange;
    public GameObject AttackCollider;

    private float speed = 4f;

    private Vector3 target;
    private Vector3 previousPosition;
    private Vector3 velocity;

    public int maxHealth = 20;
    private int currentHealth;
    private bool isStunned = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        if (!isStunned && !anim.GetBool("IsAttackingPlayer"))
        {
            isStunned = true;
            rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(Stun());
            }
        }
    }

    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunnedDuration);
        isStunned = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
