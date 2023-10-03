using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int maxCustomers;
    int totalScore = 0;
    int currCustomer = 0;
    Transform quizManager;
    GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Spawner>().HasNextCustomer();
        currCustomer++;
    }


    // Update is called once per frame
    void Update()
    {

        /* Time to go to next level */
        if (totalScore == maxCustomers)
        {
            SceneManager.LoadScene("Level 2");
        }

        /* Time to go to next customer */
        customer = GetComponent<Spawner>().GetCurrentCustomer();
        quizManager = customer.transform.GetChild(4);
        if (quizManager.GetComponent<QuizManager>().GetScore() == 1)
        {
            currCustomer++;
            totalScore++;
            GetComponent<Spawner>().HasNextCustomer();
        }

        
    }

}
