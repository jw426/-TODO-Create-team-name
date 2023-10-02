using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System;
using System.IO;

/*
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
*/

public class ScenarioScript : MonoBehaviour
{
    [SerializeField] private GameObject TextObject;
    [SerializeField] private GameObject ExpObject;
    [SerializeField] public TextAsset emotionsJSON;

    /// <summary>
    /// This class stores the data for a single emotion
    /// </summary>
    [System.Serializable]
    public class Emotion{
        public string name;
        public string sprite;
        public int difficulty;
        public string[] scenarios;
    }

    /// <summary>
    /// This class stores the data for a list of emotions
    /// </summary>
    [System.Serializable]
    public class EmotionList{
        public Emotion[] emotions;
    }

    public EmotionList emotionList = new EmotionList();

    public Emotion chosenEmotion;

    // Start is called before the first frame update
    void Start()
    {
        // Read in the emotions.json file, parse it, and find the root element
        emotionList = JsonUtility.FromJson<EmotionList>(emotionsJSON.text);

        // Filter the root element to only include emotions with difficulty <= 3, and convert it to a list
        // For level 1. We need a variable for the level number

        Emotion[] filteredEmotionList = emotionList.emotions.Where(e => e.difficulty <= 3).ToArray();

        
        // Choose a random emotion, and for that emotion, choose a random scenario
        chosenEmotion = filteredEmotionList[UnityEngine.Random.Range(0, filteredEmotionList.Length)];
        string scenario = chosenEmotion.scenarios[UnityEngine.Random.Range(0, chosenEmotion.scenarios.Length)];

        // Set the text to have that scenario, and the expression to be the emotion's sprite
        TextScript sc = TextObject.GetComponent<TextScript>();
        sc.SetTextByString(scenario);

        ExpressionScript esc = ExpObject.GetComponent<ExpressionScript>();
        esc.SetExpressionByFile("Sprites/" + chosenEmotion.sprite);
    }
}
