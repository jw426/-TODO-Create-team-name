using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ExpressionScript : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = expression_sprites[UnityEngine.Random.Range(0, expression_sprites.Length)];
        ScenarioScript sc = customer.GetComponent<ScenarioScript>();
        string scDir = sc.curDir;

        //Debug.Log(Directory.GetFiles(Path.Combine(scDir, "sprite")));
        Debug.Log(scDir);

        string[] files = Directory.GetFiles(Path.Combine(scDir, "sprite"));
        for (int iFile = 0; iFile < files.Length; iFile++)
            {
                files[iFile] = Path.GetFileNameWithoutExtension(files[iFile]);
                files[iFile] = Path.GetFileNameWithoutExtension(files[iFile]);
            }

    
        string exp_chosen = files[UnityEngine.Random.Range(0, files.Length)];
        Debug.Log(exp_chosen);
        //GetComponent<SpriteRenderer>().sprite = exp_chosen;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(exp_chosen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
