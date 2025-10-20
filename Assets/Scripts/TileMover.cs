using System.Collections;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float tileSize = 1f;
    public LayerMask obstacleLayer;
    public Vector2Int gridSize = new Vector2Int(10, 10);
    public float inputRepeatDelay = 0.15f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private float inputTimer = 0f;
    private Vector3 lastInputDirection = Vector3.zero;

    void Start()
    {
        targetPosition = transform.position; // No snapping
    }

    void Update()
    {
        bool immediateMove = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                             Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);

// Then in Update():
        if (!isMoving)
        {
            Vector3 inputDir = GetInputDirection();

            if (inputDir != Vector3.zero)
            {
                inputTimer += Time.deltaTime;

                if (immediateMove || inputTimer >= inputRepeatDelay)
                {
                    inputTimer = 0f;
                    lastInputDirection = inputDir;

                    Vector3 destination = targetPosition + inputDir * tileSize;

                    // ✅ Check both bounds and obstacles
                    if (IsWithinBounds(destination) && !IsBlocked(destination))
                    {
                        StartCoroutine(MoveToPosition(destination));
                    }
                }
            }
            else
            {
                inputTimer = 0f;
                lastInputDirection = Vector3.zero;
            }
        }


    }

    Vector3 GetInputDirection()
    {
        if (Input.GetKey(KeyCode.W)) return Vector3.forward;
        if (Input.GetKey(KeyCode.S)) return Vector3.back;
        if (Input.GetKey(KeyCode.A)) return Vector3.left;
        if (Input.GetKey(KeyCode.D)) return Vector3.right;
        return Vector3.zero;
    }

    IEnumerator MoveToPosition(Vector3 destination)
    {
        isMoving = true;

        while ((destination - transform.position).sqrMagnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        targetPosition = destination;
        isMoving = false;
    }

    bool IsWithinBounds(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x / tileSize);
        int z = Mathf.RoundToInt(position.z / tileSize);

        return x >= 0 && x < gridSize.x && z >= 0 && z < gridSize.y;
    }
    
    bool IsBlocked(Vector3 destination)
    {
        // Use a box check to simulate tile-size collision detection
        float checkRadius = tileSize * 0.45f; // slightly less than full tile to avoid false positives
        Vector3 checkCenter = destination + Vector3.up * 0.5f; // Adjust height to avoid ground collisions

        return Physics.CheckBox(checkCenter, new Vector3(checkRadius, 0.5f, checkRadius), Quaternion.identity, obstacleLayer);
    }

    

}


