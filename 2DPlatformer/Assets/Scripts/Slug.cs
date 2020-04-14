using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    GameObject player;
    Transform target; // player position
    Animator slugAnim;

    public float speed;

    private bool movingright = true;

    public Transform groudDetection;
    public Transform wallDetection;

    int dmgValue = 5;

    LayerMask groundWallLayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        slugAnim = GetComponent<Animator>();
        groundWallLayer = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        RaycastHit2D groundCheck = Physics2D.Raycast(groudDetection.position, Vector2.down, 2f);

        if (groundCheck.collider == false)
        {
            if (movingright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }

        RaycastHit2D wallCheck = Physics2D.Raycast(wallDetection.position, Vector2.down, 0.02f, groundWallLayer);

        if (wallCheck.collider == true)
        {
            if (movingright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // they collide, if player on top, destroy object if not take damage
            if (target.position.y - transform.position.y > 0)
            {
                slugAnim.Play("Enemy_Death");
                Destroy(this.gameObject, 0.5f);
                GameStatus.AddScore(10);
            }
            else
            {
                GameStatus.Damage(dmgValue);
                // knockback too if possible
            }
        }
    }

}
