﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    GameObject player;
    Transform target; // player position
    Animator skelyAnim;

    public float speed;

    private bool movingright = true;

    public Transform groudDetection;
    int dmgValue = 5;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        skelyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // they collide, if player on top, destroy object if not take damage
            if (target.position.y - transform.position.y > 0)
            {
                skelyAnim.Play("Gothic_Church_Death");
                Destroy(this.gameObject, 0.5f);
                GameStatus.AddScore(15);
            }
            else
            {
                GameStatus.Damage(dmgValue);
                // knockback too if possible
            }
        }
    }
}
