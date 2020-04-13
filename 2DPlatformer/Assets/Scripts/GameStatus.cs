using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    static protected int numLives = 3;
    static protected int score = 0;
    static protected int healthScoreCheck = 0; // if 1000 points are made, 1 live extra
    static protected int hitPoints = 100;
    
    
    public static void AddScore(int s)
    {
        score += s;
        healthScoreCheck += s;
        if (healthScoreCheck >= 1000)
        {
            numLives += 1;
            healthScoreCheck -= 1000;
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetLives()
    {
        return numLives;
    }

    // "health system"
    public static int GetHealth()
    {
        return hitPoints;
    }

    public static void Damage(int damageAmount)
    {
        hitPoints -= damageAmount;
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            numLives -= 1;
            // dead, lost a life
            if (numLives <= 0)
        {
            // game over
        } else
            {
                hitPoints = 100;
            }
        }
        
        
    }

    public static void Heal(int healAmount)
    {
        hitPoints += healAmount;
        if (hitPoints > 100) hitPoints = 100;
    }

}
