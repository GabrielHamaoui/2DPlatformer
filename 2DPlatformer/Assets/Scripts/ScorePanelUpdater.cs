using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{
    public Text scoreText;
    public Text hitPointsText; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        GameObject go = GameObject.Find("GameStatus");
        if (go == null)
        {
            Debug.LogError("Failed to find object named 'GameStatus'");
            this.enabled = false;
            return;
        }

        GameStatus gs = go.GetComponent<GameStatus>();
        */
        scoreText.text = "   Score: 00" + GameStatus.GetScore() + " Lives: 0" + GameStatus.GetLives();
        hitPointsText.text = "Hit Points: " + GameStatus.GetHealth();
    }
}
