using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMainLevel : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
