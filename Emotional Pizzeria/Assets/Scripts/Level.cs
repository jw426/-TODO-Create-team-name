using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int numCustomers;
    [SerializeField] GameObject customer;
    bool nextLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Heads to next level */
        if (nextLevel)
        {
            SceneManager.LoadScene("Level 2");
        }

        
    }

}
