using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAI : MonoBehaviour
{
    GameObject player;
    Transform target; // player position

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    int dmgValue = 20;

    Rigidbody2D rb;

    Vector2 movement;

    Animator eagleAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target =  player.transform;
        eagleAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        direction.Normalize();
        if (angle < 90 && angle > -90)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        movement = direction;
    }



    private void FixedUpdate()
    {
            moveEnemy(movement);      
    }

    void moveEnemy(Vector2 direction)
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer < agroRange)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        } else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    /*
    void FollowPlayer()
    {
        // enemy is left, move right
        if (transform.position.x < target.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1); // could have used spriterenderer, but this changes the object itself much better
        } else
        {
            // move left
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }

        // if enemy above dropdown
        if (transform.position.y > target.position.y)
        {
            rb.velocity = new Vector2(0, -moveSpeed);
        }


    }
    */
    

    // on collision with player, if not from head, take damage =, i fon head destroy eagle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // they collide, if player on top, destroy object if not take damage
            if (target.position.y - transform.position.y > 0)
            {
                eagleAnim.Play("Enemy_Death");
                Destroy(this.gameObject, 0.5f);
                GameStatus.AddScore(25);
            }
            else
            {
                GameStatus.Damage(dmgValue);
                // knockback too if possible
            }
        }
    }

}
