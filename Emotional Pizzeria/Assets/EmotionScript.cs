using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EmotionScript : MonoBehaviour
{
    [SerializeField] private GameObject scManager;
    public GameObject[] emotionBtns; 
    public string correct; 
    public string[] wrongEmotions;

    // Start is called before the first frame update
    void Start()
    {
        ScenarioScript sc = scManager.GetComponent<ScenarioScript>();
        correct = Path.GetFileNameWithoutExtension(ScenarioScript.text);
        Debug.Log(correct);

        int correctBtn = UnityEngine.Random.Range(0, emotionBtns.Length - 1);
        Debug.Log(correctBtn);

        string wrong = Path.Combine(ScenarioScript.curDir, "WrongEmotions.txt");
        StreamReader reader = new StreamReader(wrong);
        wrongEmotions = reader.ReadToEnd().Split("\n");

        for (int i = 0; i < emotionBtns.Length; i++) {
        Answers asc = emotionBtns[i].GetComponent<Answers>();
            if (i == correctBtn) {
                asc.assignValue(correct, true);
            } else {
                string wrongEmotion = wrongEmotions[UnityEngine.Random.Range(0, wrongEmotions.Length - 1)]; 
                asc.assignValue(wrongEmotion, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
