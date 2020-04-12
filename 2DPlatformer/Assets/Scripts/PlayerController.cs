using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRend;

    [SerializeField]
    private float speed = 8f;

    [SerializeField]
    private float jumpVelocity = 8f;


    [SerializeField]
    private LayerMask groundLayerMask;

    private CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // regarding animationss
    private void LateUpdate()
    {
        // JUMP
        if ((IsGrounded() && Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()))
        {
            animator.SetTrigger("takeOf");
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
            
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.01f;
        RaycastHit2D rayCastHit = Physics2D.CircleCast(circleCollider2D.bounds.center, 0.45f /*radius*/, Vector2.down, circleCollider2D.bounds.extents.y + extraHeight, groundLayerMask);
        Color rayColor;
        if (rayCastHit.collider != null)
        {
            rayColor = Color.green;
        } else
        {
            rayColor = Color.red;
        }
        // Debug.DrawRay(circleCollider2D.bounds.center, Vector2.down * (circleCollider2D.bounds.extents.y + extraHeight), rayColor);
        // Debug.Log(rayCastHit.collider);
        return rayCastHit.collider != null;
    }

    // fixed timesteps and more accurate for physics
    private void FixedUpdate()
    {


        // LEFT, RIGHT & IDLE
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.Play("Player_Run");
            spriteRend.flipX = true;

        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.Play("Player_Run");
            spriteRend.flipX = false;

        } else
        {            

            animator.Play("Player_Idle");
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        // JUMP
        if ((IsGrounded() && Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()))
        {            
            rb.velocity = Vector2.up * jumpVelocity;
            // animator.SetTrigger("takeOf");
        }

       

    }

}
