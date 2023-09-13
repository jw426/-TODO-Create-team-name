using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenarioScript : MonoBehaviour
{
    public string[] dir; 
    public string curDir; 

    // Start is called before the first frame update
    void Start()
    {
        dir = Directory.GetDirectories("Assets/Resources/Scenarios");
        curDir = dir[Random.Range(0, dir.Length)];
        //Debug.Log("Hello" + curDir);
    }
}
