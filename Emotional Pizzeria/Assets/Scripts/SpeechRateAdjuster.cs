using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class which works as a central handler for how sliders in the game are updated.
/// 
/// Update to be called 'SliderAdjuster' later and delete 'BGM/SpeechRateAdjuster' since
/// this class achieves their functionality.
/// 
/// </summary>
public class SpeechRateAdjuster : MonoBehaviour
{


    private float speechRate;
    private int SPEECH_DIVIDER = 20;
    private float DEFAULT_TIME_BETWEEN_CHARS = 0.1f;

    /// <summary>
    /// Start is called before the first frame update
    /// Author - Rimon, 21/09/2023
    /// </summary>
    void Start()
    {
        speechRate = PlayerPrefs.GetFloat("speechRate");
        this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("speechRate");
    }

    /// <summary>
    /// Method to just update the rate at which speech changes when the slider is active.
    /// </summary>
    void changeSpeechRate()
    {
        PlayerPrefs.SetFloat("speechRate", this.gameObject.GetComponent<Slider>().value);
        PlayerPrefs.Save();
        TextScript.timeBtwChars = DEFAULT_TIME_BETWEEN_CHARS - (speechRate / SPEECH_DIVIDER);
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
        changeSpeechRate();
    }
}