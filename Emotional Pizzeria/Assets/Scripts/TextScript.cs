using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp; 

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void SetText(string path) {
        Debug.Log(path);

        string[] files = Directory.GetFiles(Path.Combine(path, "situation"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        StreamReader reader = new StreamReader(sit_chosen);
        string situation = reader.ReadToEnd();
        tmp.text = situation;
    }
}
