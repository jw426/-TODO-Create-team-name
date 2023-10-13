using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{ 

    public int CountFPS = 1; 
    public float Duration = 1f; 
    private Coroutine CountingCoroutine; 
    [SerializeField] private TMP_Text tmp; 
    private static int currScore; 
    [SerializeField] private AudioSource cashierSound; 

    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
        tmp.text = currScore.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // increments the score and changes the scoreboard 
    public void IncrementScoreBy(int by) 
    {
        cashierSound.Play();
        UpdateText(currScore + by);
        currScore += by;
        //Debug.Log("currScore is: " + currScore);
        // ScoreScript sc = scoreManager.GetComponent<ScoreScript>();
    }

    // number incrementing effect
    private void UpdateText(int newScore) 
    {
        if (CountingCoroutine != null) 
        {
            StopCoroutine(CountingCoroutine);
        }
        CountingCoroutine = StartCoroutine(CountText(newScore));
    }

    private IEnumerator CountText(int newScore) 
    {
        WaitForSeconds Wait = new WaitForSeconds (1f/CountFPS);
        int previousValue = currScore; 
        int stepAmount; 

        if (newScore - previousValue < 0) 
        {
            stepAmount = Mathf.FloorToInt((newScore - previousValue) / (CountFPS * Duration));
        }
        else 
        {
            stepAmount = Mathf.CeilToInt((newScore - previousValue) / (CountFPS * Duration));
        }
        Debug.Log(stepAmount);

        if (previousValue < newScore)
        {
            
            while (previousValue < newScore)
            {
                previousValue += stepAmount; 
                if (previousValue > newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
        else 
        {
            while (previousValue > newScore)
            {
                previousValue += stepAmount; 
                if (previousValue < newScore)
                {
                    previousValue = newScore;
                }
                tmp.text = previousValue.ToString();
                yield return Wait; 
            }
            
            
        }
    }
}
