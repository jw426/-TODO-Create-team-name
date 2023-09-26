using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System;
using System.IO;

public class ScenarioScript : MonoBehaviour
{
    // [SerializeField] private GameObject TextObject;
    [SerializeField] private GameObject ExpObject;
    public static string curDir; 
    public static string exp; 
    public static string text; 

    // Start is called before the first frame update
    void Start()
    {
        string[] dir = Directory.GetDirectories("Assets/Resources/Scenarios");
        curDir = dir[UnityEngine.Random.Range(0, dir.Length)];
        
        //TextScript sc = TextObject.GetComponent<TextScript>();
        text = SetText();
        // sc.Initialize(text);

        ExpressionScript esc = ExpObject.GetComponent<ExpressionScript>();
        exp = SetExpression();
        esc.Initialize(exp);
        //Debug.Log(curDir);
        //Debug.Log("Hello" + curDir);
    }

    private string SetExpression() {
    
        string[] files = Directory.GetFiles(Path.Combine(curDir, "sprite"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        for (int iFile = 0; iFile < filtered.Length; iFile++)
        {
            filtered[iFile] = Path.GetFileNameWithoutExtension(filtered[iFile]);
        }

        string exp_path = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        return exp_path; 
    }

    private string SetText() {
        
        string[] files = Directory.GetFiles(Path.Combine(curDir, "situation"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        return sit_chosen; 
        //StreamReader reader = new StreamReader(sit_chosen);
        //return reader.ReadToEnd();
        //sc.Initialize(text);
        //return text; 
    }
}
