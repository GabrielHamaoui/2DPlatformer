using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
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

    Animator beeAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        beeAnim = GetComponent<Animator>();
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
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }


    // on collision with player, if not from head, take damage =, i fon head destroy eagle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // they collide, if player on top, destroy object if not take damage
            if (target.position.y - transform.position.y > 0)
            {
                beeAnim.Play("Enemy_Death");
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
