using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    public float radius;
    public LayerMask enemies;
    public Animator anim;
    public GameObject Slash;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == -1)
        {
            Flip();
        }
        else if (horizontal == 1) 
        {
            Flip();
        }
        if (horizontal > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        if (horizontal < 0)
        {
            anim.SetBool("IsWalking", true);
        }
        if(horizontal == 0)
        {
            anim.SetBool("IsWalking", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Slash.SetActive(true);
            anim.SetBool("IsAttacking", true);
        }
    }
    private void LateUpdate()
    {
        if(anim.GetBool("IsAttacking") && Slash.active)
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
