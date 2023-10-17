using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
=======

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
>>>>>>> fixed_typing
    }
}
