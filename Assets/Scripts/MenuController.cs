
/************************************************************
 * COPYRIGHT:  2025
 * PROJECT: Puzzle Game
 * FILE NAME: MenuController.cs
 * DESCRIPTION: Manages UI related to the title screen. 
 *
 * REVISION HISTORY:
 * Date [2025/10/20] | Ava Boswell | this partially works
 * ------------------------------------------------------------
 * 2025/10/15 | Ava Boswell | Created class
 *
 *
 ************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject settingsPanel;

    public string gameSceneName = "Proto"; // Assign your first scene here

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}