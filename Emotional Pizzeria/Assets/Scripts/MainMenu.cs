using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        string currScene = SceneManager.GetActiveScene().name;
        if (currScene == "Start Scene")
        { //Logo w/ music, not main menu

        }
    }

    /* Main Menu Options */

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("The game has started.");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
        Debug.Log("Instructions.");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Settings.");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    /* Loading Other Scenes */
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main menu");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
        Debug.Log("The game has started.");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
        Debug.Log("The game has started.");
    }

    public void LoadSummary()
    {
        SceneManager.LoadScene("Summary");
        Debug.Log("The game has ended.");
    }


    // public void NextInstructionPage() {
    //     Page1.SetActive(false);
    //     Page2.SetActive(true);
    //     GameObject.Find("NextButton").SetActive(false);
    //     GameObject.Find("ReturnButton").SetActive(false);
    // }


}
