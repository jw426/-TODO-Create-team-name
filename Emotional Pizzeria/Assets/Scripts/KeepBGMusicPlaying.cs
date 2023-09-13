using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Script to ensure the background music persists across scenes
/// Author: Rimon; last date modified - 14 September 2023
/// </summary>
public class KeepBGMusicPlaying : MonoBehaviour
{
    // Credit to the following Unity tutorial:
    // https://www.youtube.com/watch?v=I_ZbPiI5p88
    // Start is called before the first frame update
    static bool audioHasStarted = false;

/// <summary>
/// Author - Rimon; last date modified - 14 September 2023
/// 
/// Just initializes our script by checking if there's any BGM already playing-- if that's the case
/// we let the music play and have it persist, otherwise we stop it from running.
/// </summary>
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("bgm");
        /* At any given moment, we should have only one background music track playing-- if there's already
         * BGM audio playing then we should delete this audio track. */
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            /* Keep the gameobject for audio persisting between scenes */
            DontDestroyOnLoad(this.gameObject);
        }
    }

/// <summary>
/// author - Rimon; last date modified - 14 September 2023
/// Just runs a check every frame to see if we've moved into the Level One scene-- if we do then we should stop playing
/// the audio.
/// </summary>
    void Update()
    {
        /* We only stop the music from playing once we enter level 1 */
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Destroy(this.gameObject);
        }
    }
}
