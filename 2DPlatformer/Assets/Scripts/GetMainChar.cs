using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{

    public GameObject squirel, bunny;
    private Vector2 initialPosition;
    private Vector2 offScreenPos;
    private SpriteRenderer bunnyRend, squirelRend;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        initialPosition = this.transform.position;
        offScreenPos = squirel.transform.position;
        bunnyRend = bunny.GetComponent<SpriteRenderer>();
        squirelRend = squirel.GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        switch(getCharacter)
        {
            case 1:
                squirel.transform.position = offScreenPos;
                squirelRend.enabled = false;
                bunnyRend.enabled = true;
                bunny.transform.position = initialPosition;
                break;
            case 2:
                squirel.transform.position = initialPosition;
                squirelRend.enabled = true;
                bunnyRend.enabled = false;
                bunny.transform.position = offScreenPos;
                break;
            default:
                break;
        }
    }


}
