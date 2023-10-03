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

        Debug.Log("total score" + totalScore);
        /* Player has successfully taken all customers' orders */
        if (totalScore == maxCustomers)
        {
            SceneManager.LoadScene("Level 2");
        }

        Debug.Log("currCustomer" + currCustomer);
        /* Player has successfully taken current customer's order */

        customer = GetComponent<Spawner>().GetCurrentCustomer();
        quizManager = customer.transform.GetChild(4);
        Debug.Log("quiz score" + quizManager.GetComponent<QuizManager>().GetScore());

        if (quizManager.GetComponent<QuizManager>().GetScore() == 1)
        {
            currCustomer++;
            totalScore++;
            GetComponent<Spawner>().HasNextCustomer();
        }

        
    }

}
