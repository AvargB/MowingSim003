/************************************************************
* COPYRIGHT:  2025
* PROJECT: Puzzle Game 
* FILE NAME: GameOverUI.cs
* DESCRIPTION: Manages UI related to the game over screen. 
*                   
* REVISION HISTORY:
* Date [2025/10/20] | Ava Boswell | this doesn't work. 
* ------------------------------------------------------------
* 2025/10/15 | Ava Boswell | Created class
*
*
************************************************************/


using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public string nextSceneName; // Assign in Inspector

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Resume time in case it's paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        // If in editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}