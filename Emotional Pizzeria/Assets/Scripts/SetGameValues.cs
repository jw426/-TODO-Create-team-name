using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setVolume();

    }

    void setVolume()
    {
        if (this.gameObject.tag.Equals("sfx"))
        {
            if (PlayerPrefs.HasKey("sfxVolume"))
            {
                this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sfxVolume");
            }
            else
            {
                PlayerPrefs.SetFloat("sfxVolume", 0.5f);
                PlayerPrefs.Save();
                this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sfxVolume");
            }
        }
        if (this.gameObject.tag.Equals("bgm"))
        {
            if (PlayerPrefs.HasKey("bgmVolume"))
            {
                this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgmVolume");
            }
            else
            {
                PlayerPrefs.SetFloat("bgmVolume", 0.5f);
                PlayerPrefs.Save();
                this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgmVolume");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //setVolume();
    }
}
