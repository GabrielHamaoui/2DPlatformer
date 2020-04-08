using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_Script : MonoBehaviour
{

    public GameObject Squirel;
    public GameObject Bunny;

    private Vector2 CharacterPosition;
    private Vector2 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer BunnyRender, SquirelRender;

    private readonly string selectedCharacter = "SelectedCharacter";

    // before the game
    private void Awake()
    {
        CharacterPosition = Squirel.transform.position;
        OffScreen = Bunny.transform.position;
        BunnyRender = Bunny.GetComponent<SpriteRenderer>();
        SquirelRender = Squirel.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    {
        switch(CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                SquirelRender.enabled = false;
                Squirel.transform.position = OffScreen;
                Bunny.transform.position = CharacterPosition;
                BunnyRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                SquirelRender.enabled = true;
                Squirel.transform.position = CharacterPosition;
                Bunny.transform.position = OffScreen;
                BunnyRender.enabled = false;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;

        }
    }

    public void PrevCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                SquirelRender.enabled = false;
                Squirel.transform.position = OffScreen;
                Bunny.transform.position = CharacterPosition;
                BunnyRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                SquirelRender.enabled = true;
                Squirel.transform.position = CharacterPosition;
                Bunny.transform.position = OffScreen;
                BunnyRender.enabled = false;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;

        }
    }

    public void ResetInt()
    {
        if (CharacterInt > 2)
        {
            CharacterInt = 1;
        }
    }


}
