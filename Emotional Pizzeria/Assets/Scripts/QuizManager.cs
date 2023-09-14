using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA = new List<QuestionAndAnswers>();
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;
    int totalQuestions = 0;
    public int score;

/// <summary>
/// loads question
/// </summary>
    private void Start() 
    {   
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = 
    }

/// <summary>
/// removes quetsion once answered and generates new question
/// </summary>
    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

/// <summary>
/// reads input from inspector, and sets the answer as True
/// </summary>
    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

/// <summary>
/// load new question, unless out of questions
/// </summary>
    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            setAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
