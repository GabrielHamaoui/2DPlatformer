using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public float jumpForce;

    public LayerMask whatIsGround; // to detect the type of surface

    private float jumpTimeCounter; // to limit the hold to jump
    // public float jumpTime; // how long player can jump for
    private bool isJumping;

    // for ladder
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // Using blackthornprod HOW TO MAKE ANIMATION TRANSITIONS & MAKING RUN IDLE AND JUMP2D
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
    }

    private void FixedUpdate()
    {
        // horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // for animation from skip to no skip
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        // for character reflection (direction change)
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // for ladder climb
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) // maybe implement trigger
        {

            if (onLadder)
            {
                rb.gravityScale = 0f;

                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

                rb.velocity = new Vector2(rb.velocity.x, climbVelocity);

                anim.SetBool("onLadder", true);
                anim.SetBool("isJumping", false);
                anim.SetBool("isClimbing", true);
            }

        }

        if (!onLadder)
        {
            rb.gravityScale = gravityStore;

            anim.SetBool("onLadder", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbing", false);
        }



        // jump movement

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("takeOff");
            isJumping = true;
            // jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }


        /*        // on key hold jump will increase
                if (Input.GetKeyDown(KeyCode.Space) && isJumping == true)
                {
                    if (jumpTimeCounter > 0)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        jumpTimeCounter -= Time.deltaTime;
                    }
                    else { isJumping = false; }

                }
                // for double jump (?)
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    isJumping = false;
                }*/



    }
}
