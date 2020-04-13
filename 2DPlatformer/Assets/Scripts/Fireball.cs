using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    float moveSpeed = 7f;
    Rigidbody2D rb;

    GameObject player;
    Transform target; // player position

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        rb.velocity = new Vector2(-moveSpeed,0);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameStatus.Damage(25);
            Destroy(gameObject);
        }
    }
}
