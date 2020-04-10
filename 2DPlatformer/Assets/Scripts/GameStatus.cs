using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    public int numLives = 3;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        // load data from the playersprefs, from prev scene or relaoding game
        score = PlayerPrefs.GetInt("score", 0);
        numLives = PlayerPrefs.GetInt("lives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //scene changes or exit this will be called
    private void OnDestroy()
    {
        // Debug.Log("GameStatus was Destroyed");

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("lives", numLives);
    }

    public void AddScore(int s)
    {
        score += s;
    }



    /*
    Method to load next scene, put in game status if that will be in every scene      
    private void LoadScene()
    {

    }
    */
}
