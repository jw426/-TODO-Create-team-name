using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    // Credit to the following Unity tutorial:
    // https://www.youtube.com/watch?v=I_ZbPiI5p88
    // Start is called before the first frame update
    static bool audioHasStarted = false;
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("bgm");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Destroy(this.gameObject);
        }
    }
}
