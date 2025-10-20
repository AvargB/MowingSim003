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
                GameManager.Instance.CheckAllObjects();
            }
        }
    }
}