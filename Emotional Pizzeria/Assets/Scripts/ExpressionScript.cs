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
        if (this.gameObject.name == "ExpressionSummary") {
            Initialize();
        }
    }

    public void Initialize() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(ScenarioScript.exp);
    }

    public void Initialize(string sp_filename) {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sp_filename);
    }

}
