using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScenarioScript : MonoBehaviour
{
    [SerializeField] private GameObject TextObject;
    [SerializeField] private GameObject ExpObject;

    // Start is called before the first frame update
    void Start()
    {
        string[] dir = Directory.GetDirectories("Assets/Resources/Scenarios");
        string curDir = dir[Random.Range(0, dir.Length)];
        
        TextScript sc = TextObject.GetComponent<TextScript>();
        sc.SetText(curDir);

        ExpressionScript esc = ExpObject.GetComponent<ExpressionScript>();
        esc.SetExpression(curDir);
        //Debug.Log(curDir);
        //Debug.Log("Hello" + curDir);
    }
}
