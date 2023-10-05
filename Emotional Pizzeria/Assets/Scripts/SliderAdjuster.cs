using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class which works as a central handler for how sliders in the game are updated.
/// 
/// Update to be called 'SliderAdjuster' later and delete 'BGM/SpeechRateAdjuster' since
/// this class achieves their functionality.
/// 
/// </summary>
public class SFXAdjuster : MonoBehaviour
{

    /* We declare three static arrays that can work as values for how we handle the 
     * 'rate' tied to this particular item depending on if it is an SFX, BGM or 
     * speech game object.
     
     * In a later iteration we could convert this to a dictionary to make this even simpler, but
     * for now this works*/
    private static string[] sfx = { "sfxVolume", "sfx" };
    private static string[] bgm = { "bgmVolume", "bgm" };
    private static string[] speech = { "speechRate", "speech" };
    private string playerPrefKey = string.Empty;
    private string musicTag = string.Empty;

    /// <summary>
    /// Start is called before the first frame update
    /// Author - Rimon, 21/09/2023
    /// </summary>
    void Start()
    {
        /* Based on the tag associated with the game, we update the particular preferences 
         * of the game we want to be updating. */
        if (this.gameObject.tag.Equals("bgm"))
        {
            playerPrefKey = bgm[0];
            musicTag = bgm[1];
        }
        else
        {
            Debug.Log("test");
            playerPrefKey = sfx[0];
            musicTag = sfx[1];
        }
        // Once we've instantiated everything, make sure to set the slider value to what it was 
        // based on existing memory.
        this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat(playerPrefKey);
    }

    /// <summary>
    /// Method which will change the 'volume' based on an update in a slider.
    /// </summary>
    /// <param name="playerPrefKey">The particular key in playerprefs we are grabbing</param>
    /// <param name="musicTag">The tag of the game object this is tied to </param>
    void changeVolumeBasedOnSliderUpdate(string playerPrefKey, string musicTag)
    {
        PlayerPrefs.SetFloat(playerPrefKey, this.gameObject.GetComponent<Slider>().value);
        PlayerPrefs.Save();

        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag(musicTag);
        foreach (GameObject obj in sfxObjects)
        {
            AudioSource sfxAudio = obj.GetComponent<AudioSource>();
            // Update the audio to meet the current volume
            if (sfxAudio != null)
            {
                sfxAudio.volume = PlayerPrefs.GetFloat(playerPrefKey);
            }
        }
    }

    // Update is called once per frame
    /// <summary>
    /// Default Unity 'update' method-- will update the game based on changes to the slider
    /// object while active.
    /// Authored by Rimon - 21/09/2023
    /// </summary>
    void Update()
    {
        /* While the slider is active on the screen, make the game responsive to any slider changes. */
        changeVolumeBasedOnSliderUpdate(playerPrefKey, musicTag);
    }
}