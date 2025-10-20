using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class RawImageTextureChange
{
    public RawImage targetRawImage;
    public Texture newTexture;
    public int triggerCount;
    public bool hasChanged = false; // To prevent repeated changes
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TileChanger[] objectsToCheck;
    public GameObject gameOverUI;
    public GameObject[] uiElementsToHide;
    private int oneMaterialCount = 0;
    private int twoMaterialCount = 0;
    
    [Header("UI Raw Image Change")]
    public RawImage targetRawImage;
    public Texture newTexture;
    public int triggerCount = 5;
    
    [Header("Multiple Raw Image Changes")]
    public List<RawImageTextureChange> textureChangeEvents = new List<RawImageTextureChange>();


    private bool hasTextureChanged = false;


    
    public TMP_Text oneMaterialText;
    public TMP_Text twoMaterialText;
    
    

    void Awake()
    {
        Instance = this;

    }

    public void CheckAllObjects()
    {
        foreach (TileChanger obj in objectsToCheck)
        {
            if (!obj.hasChanged)
                return;
        }

        GameOver();
    }
    
    public void IncrementMaterialCount(int materialType)
    {
        if (materialType == 1)
        {
            oneMaterialCount++;
        }
        else if (materialType == 2)
        {
            twoMaterialCount++;
            CheckTextureChangeTriggers();
        }

        UpdateMaterialUI();
    }




    private void UpdateMaterialUI()
    {
        if (oneMaterialText != null)
            oneMaterialText.text = oneMaterialCount + "";

        if (twoMaterialText != null)
            twoMaterialText.text = twoMaterialCount + "";
    }


    void GameOver()
    {
        Debug.Log("Game Over! All objects have changed material.");

        // Hide other UI elements
        foreach (GameObject uiElement in uiElementsToHide)
        {
            uiElement.SetActive(false);
        }

        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void CheckTextureChangeTriggers()
    {
        foreach (RawImageTextureChange entry in textureChangeEvents)
        {
            if (!entry.hasChanged && twoMaterialCount >= entry.triggerCount)
            {
                if (entry.targetRawImage != null && entry.newTexture != null)
                {
                    entry.targetRawImage.texture = entry.newTexture;
                    entry.hasChanged = true;
                    Debug.Log($"Changed texture at threshold {entry.triggerCount}");
                }
            }
        }
    }



}