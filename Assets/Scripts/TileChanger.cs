/************************************************************
* COPYRIGHT:  2025
* PROJECT: Puzzle Game 
* FILE NAME: TileChanger.cs
* DESCRIPTION: Manages material state of tiles. 
*                   
* REVISION HISTORY:
* Date [2025/10/20] | Ava Boswell | this works beautifully, do not change anything. 
* ------------------------------------------------------------
* 2025/10/15 | Ava Boswell | Created class
*
*
************************************************************/


using Unity.VisualScripting;
using UnityEngine;


public class TileChanger : MonoBehaviour
{
    [Header("Materials")]
    public Material initialMaterial;
    public Material oneMaterial;
    public Material twoMaterial;


    private Renderer planeRenderer;
    public bool hasChanged = false;
    public bool hasChangedTwo = false;


    void Start()
    {
        planeRenderer = GetComponent<Renderer>();
      
        if (planeRenderer == null)
        {
            Debug.LogError("No Renderer found on this GameObject.");
            return;
        }


        if (initialMaterial != null)
        {
            planeRenderer.material = initialMaterial;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
    
        if (!hasChanged)
        {
            if (oneMaterial != null)
            {
                planeRenderer.material = oneMaterial;
                hasChanged = true;

                GameManager.Instance.IncrementMaterialCount(1); // Count material 1
                GameManager.Instance.CheckAllObjects();
                return;
            }
        }

        if (hasChanged && !hasChangedTwo)
        {
            if (twoMaterial != null)
            {
                planeRenderer.material = twoMaterial;
                hasChangedTwo = true;

                GameManager.Instance.IncrementMaterialCount(2); // Count material 2
                GameManager.Instance.CheckAllObjects();
            }
        }
    }

}