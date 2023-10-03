using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int maxCustomers;
    [SerializeField] GameObject customer;
    int score = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* Head to next level */
        if (score == maxCustomers)
        {
            SceneManager.LoadScene("Level 2");
        }


        GetComponent<Spawner>().HasNextCustomer();


        
    }

}
