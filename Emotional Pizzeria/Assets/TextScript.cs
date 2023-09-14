using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    [SerializeField] private TMP_Text tmp; 

    // Start is called before the first frame update
    void Start()
    {
        /*
        //GetComponent<SpriteRenderer>().sprite = expression_sprites[UnityEngine.Random.Range(0, expression_sprites.Length)];
        ScenarioScript sc = customer.GetComponent<ScenarioScript>();
        string scDir = sc.curDir;
        Debug.Log(sc.curDir);

        //Debug.Log(Directory.GetFiles(Path.Combine(scDir, "sprite")));

        string[] files = Directory.GetFiles(Path.Combine(scDir, "situation"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
       
        StreamReader reader = new StreamReader(sit_chosen);
        string situation = reader.ReadToEnd();
        tmp.text = situation;
        //Debug.Log(situation);
        */
   
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
