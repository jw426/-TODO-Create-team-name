using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ExpressionScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void SetExpressionByFolder(string path) {
    
        string[] files = Directory.GetFiles(Path.Combine(path, "sprite"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        for (int iFile = 0; iFile < filtered.Length; iFile++)
        {
            filtered[iFile] = Path.GetFileNameWithoutExtension(filtered[iFile]);
        }

        string exp_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(exp_chosen);
    }
    
    public void SetExpressionByFile(string path) {
        Debug.Log(path);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }
}