using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
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

    // Start is called before the first frame update
    void Start()
    {
        // Read in the emotions.json file, parse it, and find the root element
        emotionList = JsonUtility.FromJson<EmotionList>(emotionsJSON.text);

        // Filter the root element to only include emotions with difficulty <= 3, and convert it to a list
        // For level 1. We need a variable for the level number

        Emotion[] filteredEmotionList = emotionList.emotions.Where(e => e.difficulty <= 3).ToArray();

        
        // Choose a random emotion, and for that emotion, choose a random scenario
        Emotion emotion = filteredEmotionList[UnityEngine.Random.Range(0, filteredEmotionList.Length)];
        string scenario = emotion.scenarios[UnityEngine.Random.Range(0, emotion.scenarios.Length)];

        // Set the text to have that scenario, and the expression to be the emotion's sprite
        TextScript sc = TextObject.GetComponent<TextScript>();
        sc.SetTextByString(scenario);

        ExpressionScript esc = ExpObject.GetComponent<ExpressionScript>();
        esc.SetExpressionByFile("Sprites/" + emotion.sprite);
    }
}
