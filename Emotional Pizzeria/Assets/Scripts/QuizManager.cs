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
    [SerializeField] private GameObject scoreManager; 
    [SerializeField] private GameObject scManager;
    [SerializeField] private GameObject[] qualityIcon;


    public GameObject QuizPanel;
    //public GameObject GoPanel;

    public TMP_Text ScoreTxt;
    int totalQuestions = 0;
    int score = 0;
    int wrongCount = 0;

/// <summary>
/// loads question
/// </summary>
    private void Start() 
    {   
        totalQuestions = QnA.Count;
        GameObject[] sms = GameObject.FindGameObjectsWithTag("scoreManager");
        if (sms.Length > 0) scoreManager = sms[0];
        else Debug.Log("score manager not correctly assigned");
        //GoPanel.SetActive(false);
        //generateQuestion();
    }

    //public void retry()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
    
    //public void nextLevel()
    //{
    //    SceneManager.LoadScene("Level 2");
    
    //}

    //void GameOver()
    //{
    //    QuizPanel.SetActive(false);
    //    //GoPanel.SetActive(true);

    //    ScoreTxt.text = "Score: " + score + "/" + totalQuestions + "\n Hearts earned: ???";
    //}


    public void SubmitOrder()
    {
        /*
        GameObject summary = GameObject.FindGameObjectsWithTag("summary")[0];
        ScenarioScript scc = scManager.GetComponent<ScenarioScript>();
        summary.GetComponent<SummaryScript>().assignValue(ScenarioScript.exp, scc.chosenEmotion.name);
        */
        score = 1;
        
        ScoreScript sc = scoreManager.GetComponent<ScoreScript>();
        sc.IncrementScoreBy(20 - 5*wrongCount);
        QuizPanel.SetActive(false);
    }

    /// <summary>
    /// removes quetsion once answered and generates new question
    /// </summary>
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
        // score = 1;
        // QuizPanel.SetActive(false);
        
        //QnA.RemoveAt(currentQuestion);
        //generateQuestion();
    }

    public void wrong()
    {
        // sound effect
        wrongAnswer.Play();
        if (wrongCount < 3) {
            GameObject heartSprite = qualityIcon[wrongCount++];
            heartSprite.GetComponent<Image>().color = new Color(0,0,0,174);
        }

        //score = 0;
        // when incorrect
        //QnA.RemoveAt(currentQuestion);
        //generateQuestion();
    }

    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// reads input from inspector, and sets the answer as True
    /// </summary>
    //void setAnswers()
    //{
    //    for (int i = 0; i < options.Length; i++)
    //    {
    //        options[i].GetComponent<Answers>().isCorrect = false;
    //        options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

    //        if(QnA[currentQuestion].CorrectAnswer == i+1)
    //        {
    //            options[i].GetComponent<Answers>().isCorrect = true;
    //        }
    //    }
    //}

    /// <summary>
    /// load new question, unless out of questions
    /// </summary>
    //void generateQuestion()
    //{
    //    if(QnA.Count > 0)
    //    {
    //        currentQuestion = Random.Range(0, QnA.Count);
    //        QuestionTxt.text = QnA[currentQuestion].Question;
    //        setAnswers();
    //    }
    //    else
    //    {
    //        Debug.Log("Out of Questions");
    //        //GameOver();
    //    }
    //}
}
