using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D ColliderSlash;
    [SerializeField] private BoxCollider2D box2d;

    [SerializeField] private Healthbar healthbar;
    [SerializeField] private StaminaBar staminabar;

    public float playerHealth;
    public float playerStamina;

    private float horizontal;
    private float speed = 8f;
    public float dodgeSpeed = 12f;
    private bool isFacingRight = true;
    public float radius;
    public LayerMask enemies;
    public Animator anim;
    public GameObject Slash;
    private void Awake()
    {
        healthbar = FindObjectOfType<Healthbar>();
        staminabar = FindObjectOfType<StaminaBar>(); 
    }

    private void Update()
    {
        if (healthbar != null)
        {
            playerHealth = healthbar.health;
        }
        if (staminabar != null)
        {
            playerStamina = staminabar.stamina;
        }
        if (!anim.GetBool("IsDodging"))
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal != 0)
            {
                Flip();
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }

            if (Input.GetButtonDown("Fire1") && !anim.GetBool("IsAttacking"))
            {
                StartCoroutine(PerformAttack());
            }

            if (Input.GetButtonDown("Dodge") && playerStamina > 9 && !anim.GetBool("IsAttacking") && !anim.GetBool("IsDodging"))
            {
                StartCoroutine(PerformDodge());
            }
        }
        if(Input.GetKeyDown(KeyCode.L)) 
        {
            Debug.Log("Health" + playerHealth);
            Debug.Log("Stamina" + playerStamina);
        }
    }

    private IEnumerator PerformAttack()
    {
        ColliderSlash.enabled = true;
        anim.SetBool("IsAttacking", true);
        speed = 0f;
        yield return new WaitForSeconds(0.4f);
        Slash.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("IsAttacking", false);
        Slash.SetActive(false);
        speed = 8f;
        ColliderSlash.enabled = false;
    }

    private IEnumerator PerformDodge()
    {
        box2d.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsDodging", true);
        float dodgeDirection = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(dodgeDirection * dodgeSpeed, rb.velocity.y);
        yield return new WaitForSeconds(0.3f);
        rb.constraints = RigidbodyConstraints2D.None;
        anim.SetBool("IsDodging", false);
        box2d.enabled = true;
    }

    private void FixedUpdate()
    {
        if (!anim.GetBool("IsDodging"))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f && !anim.GetBool("IsAttacking") || !isFacingRight && horizontal > 0f && !anim.GetBool("IsAttacking"))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
