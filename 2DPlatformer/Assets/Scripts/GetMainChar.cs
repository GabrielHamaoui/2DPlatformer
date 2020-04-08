using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{

    public Sprite squirel, bunny;
    private SpriteRenderer mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        switch(getCharacter)
        {
            case 1:
                //mySprite.gameObject = squirel;
                break;
            case 2:
                mySprite.sprite = bunny;
                break;
            default:
                break;
        }
    }


}
