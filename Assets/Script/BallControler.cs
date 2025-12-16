using UnityEngine;
using UnityEngine.InputSystem;

public class BallControler : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput input;

    private bool isGrounded;

    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 6f;

    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float fallLimitY = -10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = input.actions["Move"].ReadValue<Vector2>();
        rb.linearVelocity = new Vector3(
            moveInput.x * speed,
            rb.linearVelocity.y,
            moveInput.y * speed
        );
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        // Respawn si cae
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = respawnPoint.position;
    }
}