using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    private int gemValue = 100;

    private bool isColliding;

    // on collision with player, destroy the gem object and add points to score
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding) return;
        isColliding = true;
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameStatus.AddScore(gemValue);
        }                
    }

    private void Update()
    {
        isColliding = false;
    }

}
