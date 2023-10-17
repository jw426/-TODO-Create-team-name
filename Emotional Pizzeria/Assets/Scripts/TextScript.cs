using System;
using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;

    private string txt; 

    /// <summary>
    /// This function chooses a random scenario from the folder "situation" in the given path
    /// </summary>
    /// <param name="path"></param>
    public void SetTextByPath(string path) {
        Debug.Log(path);

        string[] files = Directory.GetFiles(Path.Combine(path, "situation"));
        string[] filtered = Array.FindAll(files, files => 
                                            !files.EndsWith("meta"));

<<<<<<< HEAD
        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
        StreamReader reader = new StreamReader(sit_chosen);
        string situation = reader.ReadToEnd();
=======
        //sc = scManager.GetComponent<ScenarioScript>();
        if (gameObject.name == "ScenarioSummary")
        {
            Initialize();
        }

    }

    private void Update() {

        if (gameObject.name == "ScenarioSummary")
        {
            return;
        }

        if (ScenarioScript.text != null && !running)
        {
            running = true;
            InitializeByString(ScenarioScript.text);
        }

        if (textFinished || (textFinished && Input.GetMouseButtonDown(0)))
        {
            takeOrder.SetActive(true);
        }

        if (!textSkipped && Input.GetMouseButtonDown(0))
        {
            textSkipped = true;
            textFinished = true;
        }

    }



    public void Initialize() {

        
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        //StreamReader reader = new StreamReader(ScenarioScript.text);
        //tmp.text = reader.ReadToEnd();
        tmp.text = ScenarioScript.text; 
        //Debug.Log("here");
        
        //Debug.Log(sc.curDir);
        //Debug.Log(sc.text);
        //tmp.text = situation;
        //tmp.text = sc.text; 
        //TypeWriterTMP(situation);
    }

    public void Initialize(string path) {

        //Debug.Log("this is triggered");
        
        //Debug.Log(path);
        StreamReader reader = new StreamReader(path);
>>>>>>> fixed_typing

        //tmp.text = situation;
        tmp.text = "";
        txt = situation;
        StartCoroutine("TypeWriterTMP");
        //TypeWriterTMP(situation);
    }

<<<<<<< HEAD
    /// <summary>
    /// This function sets the text to the given string
    /// </summary>
    /// <param name="text"></param>
    public void SetTextByString(string text) {
        tmp.text = "";
        txt = text;
        StartCoroutine("TypeWriterTMP");
=======
    public void InitializeByString(string scenario)
    {

        //Debug.Log("this is triggered");

        //Debug.Log(path);
        //tmp.text = situation;
        Debug.Log("tmp.text initialise " + tmp.text);
        tmp.text = "";
        txt = scenario;
        Debug.Log("txt " + txt);
        StartCoroutine("TypeWriterTMP");       
        //TypeWriterTMP(situation);
>>>>>>> fixed_typing
    }

    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSecondsRealtime(delayBeforeStart);

        foreach (char c in txt)
        {
<<<<<<< HEAD
=======
            if (textSkipped) {
                tmp.text = txt; 
                break; 
            }

>>>>>>> fixed_typing
            tmp.text += c;
            yield return new WaitForSecondsRealtime(timeBtwChars);
        }
    }
<<<<<<< HEAD
}
=======


}


//public class TextScript : MonoBehaviour
//{
//    [SerializeField] private TMP_Text tmp;
//    [SerializeField] private Coroutine coroutine;

//    [SerializeField] float delayBeforeStart = 0f;
//    [SerializeField] float timeBtwChars = 0.1f;

//    private string txt; 

//    /// <summary>
//    /// This function chooses a random scenario from the folder "situation" in the given path
//    /// </summary>
//    /// <param name="path"></param>
//    public void SetTextByPath(string path) {
//        Debug.Log(path);

//        string[] files = Directory.GetFiles(Path.Combine(path, "situation"));
//        string[] filtered = Array.FindAll(files, files => 
//                                            !files.EndsWith("meta"));

//        string sit_chosen = filtered[UnityEngine.Random.Range(0, filtered.Length)];
//        StreamReader reader = new StreamReader(sit_chosen);
//        string situation = reader.ReadToEnd();

//        //tmp.text = situation;
//        tmp.text = "";
//        txt = situation;
//        StartCoroutine("TypeWriterTMP");
//        //TypeWriterTMP(situation);
//    }

//    /// <summary>
//    /// This function sets the text to the given string
//    /// </summary>
//    /// <param name="text"></param>
//    public void SetTextByString(string text) {
//        tmp.text = "";
//        txt = text;
//        StartCoroutine("TypeWriterTMP");
//    }

//    IEnumerator TypeWriterTMP()
//    {
//        yield return new WaitForSeconds(delayBeforeStart);

//        foreach (char c in txt)
//        {
//            tmp.text += c;
//            yield return new WaitForSeconds(timeBtwChars);
//        }
//    }
//}
>>>>>>> fixed_typing
