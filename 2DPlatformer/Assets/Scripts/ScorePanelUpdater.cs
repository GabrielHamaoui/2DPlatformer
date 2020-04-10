using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameStatus");
        if (go == null)
        {
            Debug.LogError("Failed to find object named 'GameStatus'");
            this.enabled = false;
            return;
        }

        GameStatus gs = go.GetComponent<GameStatus>();

        GetComponent<Text>().text = "   Score: 00" + gs.score + " Lives: 0" + gs.numLives;
    }
}
