using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 */
public class BGMAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); 
        // We want the slider's effects to persist! We should unconditionally not destroy it.
    }

    // Update is called once per frame
    void Update()
    {
        /* Iterate over all SFX game objects and adjust their volume. */
        GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("bgm");
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
