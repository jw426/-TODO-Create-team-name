using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;

    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject customer; 
    [SerializeField] private GameObject takeOrder; 
    [SerializeField] private GameObject scManager;  

    private bool textSkipped = false; 
    public bool textFinished = false; 
    private static bool updateOn = true; 
    private string txt; 


    void Start() {

        if (this.gameObject.name == "ScenarioSummary") {
            Initialize();
        }
    }

    private void Update() {

        if (this.gameObject.name == "ScenarioSummary") {
            return;
        }

        if (textFinished || (textFinished && Input.GetMouseButtonDown(0))) {
            takeOrder.SetActive(true);
        }
        
        if (!textSkipped && Input.GetMouseButtonDown(0)) {
                Debug.Log("Left mouse was clicked.");
                textSkipped = true;
                textFinished = true; 
        }
        
    }

    public void Initialize() {

        
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        StreamReader reader = new StreamReader(ScenarioScript.text);
        tmp.text = reader.ReadToEnd();
        
        //Debug.Log(sc.curDir);
        //Debug.Log(sc.text);
        //tmp.text = situation;
        //tmp.text = sc.text; 
        //TypeWriterTMP(situation);
    }

    public void Initialize(string path) {
        
        StreamReader reader = new StreamReader(path);

        //tmp.text = situation;
        tmp.text = "";
        txt = reader.ReadToEnd();
        StartCoroutine("TypeWriterTMP");
        //TypeWriterTMP(situation);
    }

    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in txt)
        {
            if (textSkipped) {
                Debug.Log("Text skipped!");
                tmp.text = txt; 
                break; 
            }
           
            tmp.text += c;
            yield return new WaitForSeconds(timeBtwChars);
        }

        textFinished = true; 
    }

 
}
