using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer render;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        /* 
            Send movement information to animator, 
            horizontal looks the same so we take the absolute value 
            and flip the renderer instead
        */
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Vertical", rb.velocity.y);

        // Used to manage idle
        animator.SetBool("Walking", rb.velocity.magnitude > 0f);
        if (Mathf.Abs(rb.velocity.y) > 0f)
            animator.SetBool("DirectionUpwards", rb.velocity.y > 0f);
        if (Mathf.Abs(rb.velocity.x) > 0f)
            render.flipX = rb.velocity.x < 0;
    }
}
