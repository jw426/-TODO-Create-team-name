using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 */
public class SFXAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("SFXHandler");
        /* At any given moment, we should have only one slider managing the SFX stuff */
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            /* Don't destroy it if it's the first initialization of our SFX Volume Slider */
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("running");
        /* Iterate over all SFX game objects and adjust their volume. */
        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("sfx");
        foreach (GameObject obj in sfxObjects) {
            AudioSource sfxAudio = obj.GetComponent<AudioSource>();
            // Update the audio to meet the current volume
            if (sfxAudio != null)
            {
                sfxAudio.volume = this.gameObject.GetComponent<Slider>().value;
            }
        }
    }
}
