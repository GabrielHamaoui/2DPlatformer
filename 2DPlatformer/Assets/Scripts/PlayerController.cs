using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRend;

    private float speed = 7.0f;


    bool isGrounded;

    [SerializeField]
    Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // fixed timesteps and more accurate for physics
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        } else 
        {
            isGrounded = false;
        }


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.Play("Player_Run");
            spriteRend.flipX = false;
        } else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.Play("Player_Run");
            spriteRend.flipX = true;
        } else
        {
            //if (isGrounded == false)
            //{
            //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            //}
            animator.Play("Player_Idle");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 4);
            if (rb.velocity.y > 0.1)
            {
                animator.Play("Player_Jump_Up");
            }
            if (rb.velocity.y < -0.1)
            {
                animator.Play("Player_Jump_Down");
            }
        }


    }


}
