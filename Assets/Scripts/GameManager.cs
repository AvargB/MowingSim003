using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TileChanger[] objectsToCheck;
    public GameObject gameOverUI;

    void Awake()
    {
        Instance = this;
        
    }

    public void CheckAllObjects()
    {
        foreach (TileChanger obj in objectsToCheck)
        {
            if (!obj.hasChanged)
            {
                return; // At least one object hasn't changed yet
            }
        }

        GameOver();
    }

    void GameOver()
    {
        Debug.Log("Game Over! All objects have changed material.");
        gameOverUI.SetActive(true);
        // Optionally: Pause the game
        Time.timeScale = 0f;
    }
}
