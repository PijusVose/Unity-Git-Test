using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction inputAction;

    [Header("Player Settings")]
    [SerializeField]
    private float movementSpeed = 5f;

    private Vector2 movementInput;
    private Rigidbody rb;

    private void Awake() {
        inputAction.performed += OnMovementInput;

        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(movementInput.x * movementSpeed, rb.velocity.y, movementInput.y * movementSpeed);
    }
}
