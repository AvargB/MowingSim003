using UnityEngine;

public class TileChanger : MonoBehaviour
{
    [Header("Materials")]
    public Material initialMaterial;
    public Material newMaterial;

    private Renderer planeRenderer;
    private bool hasChanged = false;

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
            if (newMaterial != null)
            {
                planeRenderer.material = newMaterial;
                hasChanged = true;
            }

        }
    }
}