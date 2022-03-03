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
        render.flipX = rb.velocity.x < 0;
        animator.SetFloat("Vertical", rb.velocity.y);
    }
}
