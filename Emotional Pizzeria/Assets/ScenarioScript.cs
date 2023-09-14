using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenarioScript : MonoBehaviour
{
    public string[] dir; 
    public string curDir; 
    [SerializeField] private GameObject TextObject;

    // Start is called before the first frame update
    void Start()
    {
        dir = Directory.GetDirectories("Assets/Resources/Scenarios");
        curDir = dir[Random.Range(0, dir.Length)];
        

        TextScript sc = TextObject.GetComponent<TextScript>();
        sc.SetText(curDir);
        //Debug.Log(curDir);
        //Debug.Log("Hello" + curDir);
    }
}
