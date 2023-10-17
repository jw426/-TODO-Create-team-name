using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * 
 */
public class PauseMenuHandler : MonoBehaviour

{
    public static bool gamePaused = false;
    [SerializeField] GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Handle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Handle()
    {
        if (gamePaused)
        {
            ResumeGame();
            gamePaused = false;
        }
        else
        {
            PauseGame();
            gamePaused = true;
        }
    } 

    void PauseGame()
    {
        Debug.Log("hey!");
        Time.timeScale = 0f;

    }

    void ResumeGame()
    {
        Debug.Log("p");
        Time.timeScale = 1f;
    }

    /* Loading Other Scenes */
    public void ReturnToMenu()
    {
        level.GetComponent<Spawner>().RemoveCurrCustomer();
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        Debug.Log("Main menu");
    }

}
