using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int maxCustomers;
    [SerializeField] GameObject endLevel;
    int totalScore = 0;
    Transform quizManager;
    GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        endLevel.SetActive(false);
        GetComponent<Spawner>().HasNextCustomer();
    }


    // Update is called once per frame
    void Update()
    {

        /* Time to go to next level */
        if (totalScore == maxCustomers)
        {
            GetComponent<Spawner>().HasNoCustomer();

            if (GetComponent<Spawner>().customerOutStopped())
            {
                endLevel.SetActive(true);
            }
        }

        /* Time to go to next customer */
        customer = GetComponent<Spawner>().GetCurrentCustomer();
        quizManager = customer.transform.GetChild(4);
        if (quizManager.GetComponent<QuizManager>().GetScore() == 1)
        {
            totalScore++;
            GetComponent<Spawner>().HasNextCustomer();
        }


    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
