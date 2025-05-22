using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private bool isGrounded = true;

    private bool isDodging = false;
    private float dodgeCooldown = 2f;
    private float dodgeTimer = 0f;
    private float dodgeDuration = 0.3f;

    private Rigidbody rb;
    private ParticleSystem dogde;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Gameplay.Jump.performed += ctx => Jump();
        inputActions.Gameplay.Dogde.performed += ctx => Dogde();

        rb = GetComponent<Rigidbody>();
        dogde = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable() => inputActions.Gameplay.Enable();
    private void OnDisable() => inputActions.Gameplay.Disable();

    private void Update()
    {
        HandleDodgeCooldown();
        Move();
    }

    private void Move()
    {
        if (isDodging) return;
        Vector2 movement = new Vector2(moveInput.x * moveSpeed, VerticalVelocity());
        rb.linearVelocity = movement;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * Mathf.Sqrt(jumpHeight * gravity * 2), ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    private float VerticalVelocity()
    {
        // nel caso di gravity too fluffy
        // change the logic here
        return rb.linearVelocity.y;
    }

    private float GetGroundHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(rb.transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            return hit.point.y;
        }
        return rb.transform.position.y;
    }

    private void Dogde()
    {
        if (dodgeTimer > 0 || isDodging) return;

        isDodging = true;
        dodgeTimer = dodgeCooldown;
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed * 2, rb.linearVelocity.y);
        Invoke(nameof(EndDodge), dodgeDuration);
        dogde.Play();
    }

    private void EndDodge()
    {
        isDodging = false;
    }

    private void HandleDodgeCooldown()
    {
        if (dodgeTimer > 0)
            dodgeTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }
}
