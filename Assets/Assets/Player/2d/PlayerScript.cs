using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private int PlayerLife;
    private bool isFacingRight = true;
    public float radius;
    public LayerMask enemies;
    public Animator anim;

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
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.5f);
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



    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void DamagePlayer()
    {

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