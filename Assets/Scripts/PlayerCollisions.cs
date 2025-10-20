using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCollisions : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }
}