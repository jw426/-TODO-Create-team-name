using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Sprite[] character_sprites;

    /*
     * Renders the character based on a randomly chosen sprite
     */
    public void Render()
    {
        GetComponent<SpriteRenderer>().sprite = character_sprites[Random.Range(0, character_sprites.Length)];
    }
}