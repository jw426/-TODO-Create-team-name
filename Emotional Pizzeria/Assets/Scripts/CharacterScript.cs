using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public Sprite[] character_sprites;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = character_sprites[Random.Range(0, character_sprites.Length)];
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
