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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}