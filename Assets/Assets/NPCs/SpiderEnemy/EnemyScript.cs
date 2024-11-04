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

    public float horizontal;
    private float speed = 2f;
    private Transform player;
    private PlayerScript playerScript;
    private bool isStunned = false;
    private bool isPlayerInRange = false;
    private bool isAttacking = false;

    public int maxHealth = 20;
    private int currentHealth;
    private int attackDamage = 20;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player")?.transform;

        if (player != null)
        {
            playerScript = player.GetComponent<PlayerScript>();
        }

        if (playerScript == null)
        {
            Debug.LogError("PlayerScript não encontrado! Verifique se o objeto do jogador possui o script PlayerScript.");
        }
    }

    private void Update()
    {
        if (!anim.GetBool("IsAttackingPlayer") && !isPlayerInRange && player != null)
        {

            Vector2 moveDir = (player.position - transform.position);

            rb.velocity = moveDir * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            isPlayerInRange = true;
            anim.SetBool("PlayerOnRange", true);
            anim.SetBool("IsAttackingPlayer", true);
            anim.Play("SpiderAttack");
            StartCoroutine(AttackPlayer());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            anim.SetBool("PlayerOnRange", false);
            anim.SetBool("IsAttackingPlayer", false);
            anim.Play("SpiderWalk");
        }
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1f);

        if (playerScript != null)
        {
            playerScript.TakeDamage(attackDamage);
        }

        anim.SetBool("IsAttackingPlayer", false);
        anim.Play("SpiderWalk");

        yield return new WaitForSeconds(1f);
        isAttacking = false;
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
