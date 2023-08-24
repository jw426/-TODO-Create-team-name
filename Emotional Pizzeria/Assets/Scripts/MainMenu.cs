using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{  

    public void Start() {
        string currScene = SceneManager.GetActiveScene().name;
        if(currScene == "StartScene") {
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Level 1");
        Debug.Log("The game has started.");
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadInstructions() {
        SceneManager.LoadScene("Instruction");
    }

    // public void NextInstructionPage() {
    //     Page1.SetActive(false);
    //     Page2.SetActive(true);
    //     GameObject.Find("NextButton").SetActive(false);
    //     GameObject.Find("ReturnButton").SetActive(false);
    // }

    public void ExitGame() {
        Application.Quit();
    }

}
