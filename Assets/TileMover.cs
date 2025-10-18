using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float moveSpeed = 50;
    public float tileSize = 1f;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W))
                direction = Vector3.forward;
            else if (Input.GetKeyDown(KeyCode.S))
                direction = Vector3.back;
            else if (Input.GetKeyDown(KeyCode.A))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D))  
                direction = Vector3.right;
            
            if (direction != Vector3.zero)
            {
                Vector3 destination = transform.position + direction * tileSize;
                StartCoroutine(MoveToPosition(destination));
            }
        }
    }

    System.Collections.IEnumerator MoveToPosition(Vector3 destination)
    {
        isMoving = true;
        while ((destination - transform.position).sqrMagnitude < 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }
}
