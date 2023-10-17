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
    public AudioSource wrongAnswer;
    public AudioSource correctAnswer;
    [SerializeField] GameObject submitBtn; 
    [SerializeField] GameObject[] choices; 

    public GameObject QuizPanel;
    public GameObject GoPanel;

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

<<<<<<< HEAD
    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);

        ScoreTxt.text = "Score: " + score + "/" + totalQuestions + "\n Hearts earned: ???";
    }

/// <summary>
/// removes quetsion once answered and generates new question
/// </summary>
=======
    public void SubmitOrder()
    {
        score = 1;
        QuizPanel.SetActive(false);
    }

    /// <summary>
    /// removes quetsion once answered and generates new question
    /// </summary>
>>>>>>> fixed_typing
    public void correct()
    {
        // sound effect
        correctAnswer.Play();
        submitBtn.SetActive(true);

        for (int i = 0; i < choices.Length; i++) 
        {
            choices[i].GetComponent<Button>().interactable = false; 
        }
        
        // yield return new WaitForSeconds(2f);

        // when correct
<<<<<<< HEAD
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
=======
        // score = 1;
        // QuizPanel.SetActive(false);
        
        //QnA.RemoveAt(currentQuestion);
        //generateQuestion();
>>>>>>> fixed_typing
    }

    public void wrong()
    {
<<<<<<< HEAD
=======
        // sound effect
        wrongAnswer.Play();

        //score = 0;
>>>>>>> fixed_typing
        // when incorrect
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
