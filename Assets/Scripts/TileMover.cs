using System.Collections;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float tileSize = 1f;
    public LayerMask obstacleLayer;
    public Vector2Int gridSize = new Vector2Int(10, 10);
    public float inputRepeatDelay = 0.15f;
    public Vector3 gridOrigin = Vector3.zero;

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
        if (!isMoving)
        {
            Vector3 inputDir = GetInputDirection();

            if (inputDir != Vector3.zero)
            {
                if (inputDir != lastInputDirection)
                {
                    inputTimer = 0f;
                    lastInputDirection = inputDir;
                }

                inputTimer += Time.deltaTime;

                if (inputTimer >= inputRepeatDelay)
                {
                    inputTimer = 0f;

                    Vector3 destination = targetPosition + inputDir * tileSize;

                    if (IsWithinBounds(destination) && !IsObstacle(destination))
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
        Vector3 localPos = position - gridOrigin;
        int x = Mathf.RoundToInt(localPos.x / tileSize);
        int z = Mathf.RoundToInt(localPos.z / tileSize);

        return x >= 0 && x < gridSize.x && z >= 0 && z < gridSize.y;
    }

    bool IsObstacle(Vector3 position)
    {
        return Physics.CheckBox(position, Vector3.one * 0.45f, Quaternion.identity, obstacleLayer);
    }
}


