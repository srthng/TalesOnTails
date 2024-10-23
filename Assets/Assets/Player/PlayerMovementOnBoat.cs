using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementOnBoat : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    private float speed = 5f;
    private bool isFacingRight = false;
    public Animator anim;
    private Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("IsWalking",true);
        } else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    private void LateUpdate()
    {
        if (movement.x > 0)
        {
            isFacingRight = true;
        }
        else if (movement.x < 0) 
        {
            isFacingRight = false;
        }

        if (((isFacingRight) && (localScale.x < 0)) || ((!isFacingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
