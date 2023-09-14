using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 */
public class SpeechRateAdjuster : MonoBehaviour
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
        /* Not quite sure on how this is implemented-- I'll write this once we get time. */
    }
}
