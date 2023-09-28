using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private GameObject promptManager; 
    public QuizManager quizManager;

    /// <summary>
    /// reads isCorrect and generates new question through correct()
    /// </summary>
    public void assignValue(string option, bool correct) {
        isCorrect = correct;
        //EmotionScript sc = promptManager.GetComponent<EmotionScript>();
        tmp.text = option; 
    }

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Incorrect Answer");
            quizManager.wrong();
        }
    }
}
