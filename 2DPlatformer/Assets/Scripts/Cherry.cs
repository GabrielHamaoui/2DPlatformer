using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private int cherryHealthValue = 10;

    private bool isColliding;

    // on collision with player, destroy the gem object and add points to score
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isColliding) return;
            isColliding = true;
            Destroy(this.gameObject);
            GameStatus.Heal(cherryHealthValue);
        }
    }

    private void Update()
    {
        isColliding = false;
    }
}
