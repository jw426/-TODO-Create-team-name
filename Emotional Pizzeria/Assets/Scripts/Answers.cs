using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
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
            quizManager.correct();
        }
    }
}
